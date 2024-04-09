using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using (var httpClient = new HttpClient())
			{
				try
				{
					// Gọi API và nhận nội dung phản hồi
					HttpResponseMessage response = httpClient.GetAsync("https://dienmaytiendat.vn/").Result;
					response.EnsureSuccessStatusCode(); // Đảm bảo trạng thái phản hồi là 2xx

					// Đọc nội dung phản hồi
					string responseBody = response.Content.ReadAsStringAsync().Result;

					// Tạo đối tượng HtmlDocument từ nội dung HTML
					var htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(responseBody);

					// Lấy ra element đầu tiên có class "ul_menu"
					var menuElement = htmlDocument.DocumentNode.SelectSingleNode("//ul[@class='ul_menu']");
					var items = menuElement.SelectNodes("./li");
					int i = 1;
					string fileName = "categories.sql";
					items.RemoveAt(items.Count() - 1);

					JArray arr = new JArray();
					foreach (var item in items)
					{
						var aTag = item.SelectSingleNode("./a");
						var title = aTag.GetAttributeValue("title", string.Empty);
						var href = aTag.GetAttributeValue("href", string.Empty);
						var itemsChild = item.SelectNodes("./ul/li");
						var idCha = i;
						string sqlCha = $"INSERT INTO categories (id, title, href, parent_id) VALUES ({idCha}, '{title}', '{href}', null)";

						arr.Add(new JObject
						{
							{ "id",idCha },
							{ "title",title },
							{ "href",href },
							{ "parent_id",null },
						});

						i++;
						File.AppendAllText(fileName, sqlCha + Environment.NewLine);
						if (itemsChild != null)
						{
							foreach (var itemChild in itemsChild)
							{
								var aChild = itemChild.SelectSingleNode("./a");
								var titleChild = aChild.GetAttributeValue("title", string.Empty);
								var hrefChild = aChild.GetAttributeValue("href", string.Empty);
								var childId = i++;
								string sql = $"INSERT INTO categories (id, title, href, parent_id) VALUES ({childId}, '{titleChild}', '{hrefChild}', {idCha})";
								arr.Add(new JObject
								{
									{ "id",childId },
									{ "title",titleChild },
									{ "href",hrefChild },
									{ "parent_id",idCha },
								});
								File.AppendAllText(fileName, sql + Environment.NewLine);
							}

						}
					}

					JArray arrProduct = new JArray();
					int idProduct = 1;
					foreach (var item in arr)
					{
						if (string.IsNullOrEmpty(item["parent_id"].ToString())) continue;
						try
						{
							var uri = new Uri(new Uri("https://dienmaytiendat.vn/"), (string)item["href"]);
							HttpResponseMessage response2 = httpClient.GetAsync(uri).Result;
							response2.EnsureSuccessStatusCode();
							string responseBody2 = response2.Content.ReadAsStringAsync().Result;
							var htmlDocument2 = new HtmlDocument();
							htmlDocument2.LoadHtml(responseBody2);
							var productCols = htmlDocument2.DocumentNode.SelectNodes("//div[@class='product-col']");
							if (productCols == null) continue;
							foreach (var productCol in productCols)
							{
								JObject product = new JObject();
								product["id"] = idProduct++;
								product["category_id"] = item["id"];
								// Trích xuất các dữ liệu từ phần tử productCol và thêm chúng vào JObject
								string imageUrl = productCol.SelectSingleNode(".//img").GetAttributeValue("data-src", "");
								product["imageUrl"] = imageUrl;

								string title = productCol.SelectSingleNode(".//a").GetAttributeValue("title", "");
								product["title"] = title;

								string price = productCol.SelectSingleNode(".//span[@class='price product-price']").InnerText.Trim().Replace("₫", "").Replace(".", "");

								product["price"] = price;

								string productUrl = productCol.SelectSingleNode(".//a[@class='image_link display_flex']").GetAttributeValue("href", "");
								product["productUrl"] = productUrl;

								// Thêm JObject của sản phẩm vào JArray arrProduct
								arrProduct.Add(product);
								File.AppendAllText("product.sql", $"INSERT INTO products (id, category_id, imageUrl, title, price, productUrl) VALUES ({product["id"]}, {product["category_id"]}, '{product["imageUrl"]}', '{product["title"]}', {product["price"]}, '{product["productUrl"]}')" + Environment.NewLine);
							}
						}
						catch (HttpRequestException e)
						{
							Console.WriteLine($"Lỗi khi gọi API: {e.Message}");
						}

					}

					for (int temp = 0; temp < arrProduct.Count; temp++)
					{
						string href = arrProduct[temp]["href"].ToString();
						/// lấy data trang chi tiết
					}
				}
				catch (HttpRequestException e)
				{
					Console.WriteLine($"Lỗi khi gọi API: {e.Message}");
				}
			}
		}
	}
}
