using Entities.Models;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToolCaoDataDienMayTienDar
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CMS_DBContext>();
            optionsBuilder.UseMySql(
                "Server=localhost;Port=3306;Database=qlbh;Uid=root;Pwd=1234;",
                ServerVersion
                    .AutoDetect("Server=localhost;Port=3306;Database=qlbh;Uid=root;Pwd=1234;")
            );

            using var client = new System.Net.Http.HttpClient();
            using CMS_DBContext dbContext = new CMS_DBContext(optionsBuilder.Options);

            HtmlDocument doc = new HtmlDocument();
            var resMes = await client.GetAsync("https://dienmaytiendat.vn/");
            doc.LoadHtml(await resMes.Content.ReadAsStringAsync());

            var nodes = doc.DocumentNode.SelectNodes("//li[contains(@class, 'nav_item lv1')]");
            List<Tuple<ProductCategory, List<ProductCategory>>> listCate = new List<Tuple<ProductCategory, List<ProductCategory>>>();
            int id = 1;
            int cateOrder = 1;
            int productId = 1;
            foreach (var node in nodes)
            {
                int childOrder = 1;

                ProductCategory parent = CreateProductCategory(node, id++, cateOrder++, 0);
                //dbContext.ProductCategories.Add(parent);
                //await dbContext.SaveChangesAsync();

                var childNodes = node.SelectNodes("./ul/li[contains(@class, 'nav_item')]");

                if (childNodes == null) continue;

                List<ProductCategory> children = new List<ProductCategory>();
                foreach (var childNode in childNodes)
                {
                    var childCate = CreateProductCategory(childNode, id++, childOrder++, parent.Id);
                    children.Add(childCate);
                    //dbContext.ProductCategories.Add(childCate);
                    //await dbContext.SaveChangesAsync();
                }

                listCate.Add(new Tuple<ProductCategory, List<ProductCategory>>(parent, children));
            }

            var listCategory = await dbContext.ProductCategories.ToListAsync();

            foreach (var item in listCategory)
            {
                if (!(item.ParentId > 0)) continue;

                HtmlDocument docCate = new HtmlDocument();
                var resMesCate = await client.GetAsync("https://dienmaytiendat.vn/" + item.Code);
                docCate.LoadHtml(await resMesCate.Content.ReadAsStringAsync());

                var productNodes = docCate.DocumentNode.SelectNodes("//a[contains(@class, 'image_link display_flex')]");
                if (productNodes == null) continue;
                var productNodesstring = productNodes.Select(n => n.GetAttributeValue("href", ""));

                foreach (var href in productNodesstring)
                {
                    HtmlDocument docProd = new HtmlDocument();
                    var resMesProd = await client.GetAsync("https://dienmaytiendat.vn" + href);
                    docProd.LoadHtml(await resMesProd.Content.ReadAsStringAsync());
                    try
                    {
                        var product = CreateProduct(docProd.DocumentNode, productId++, item.Id, href.Trim('/'));
                        dbContext.Products.Add(product);
                        await dbContext.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        static Product CreateProduct(HtmlNode node, int id, int categoryId, string code)
        {
            Product product = new Product();
            product.Id = id;
            product.CategoryId = categoryId;
            product.Branch = node.SelectSingleNode("//span[contains(@class, 'first_status')]/span").InnerText;
            product.CreatedBy = null;
            product.CreatedDate = DateTime.Now;
            product.ModifiedBy = null;
            product.ModifiedDate = DateTime.Now;
            product.Name = node.SelectSingleNode("//h1[contains(@class, 'title-product bk-product-name')]").InnerText;
            product.IsHome = false;
            product.IsHot = false;
            product.IsPromote = false;
            product.MainImageLarge = node.SelectSingleNode("//a[contains(@class, 'large_image_url checkurl')]").GetAttributeValue("href", null).Trim('/');
            product.MainImageThumb = node.SelectSingleNode("//a[contains(@class, 'large_image_url checkurl')]").GetAttributeValue("href", null).Trim('/');
            decimal.TryParse(node.SelectSingleNode("//span[contains(@itemprop, 'price')]").InnerText.Trim('₫').Replace(".", ""), out decimal outPrice);
            product.Price = outPrice;
            product.PromotionPrice = null;
            product.Quantity = 100;
            product.Code = code;
            product.SubDes = node.SelectSingleNode("//div[contains(@class, 'rte description')]").InnerHtml.Trim();
            product.Description = node.SelectSingleNode("//div[contains(@id, 'tab-1')]/div").InnerHtml.Trim();


            return product;
        }

        static ProductCategory CreateProductCategory(HtmlNode node, int id, int cateOrder, int parentId)
        {
            ProductCategory productCategory = new ProductCategory();
            var aNode = node.SelectSingleNode("./a");
            productCategory.CategoryName = aNode.InnerText.Trim();
            productCategory.Id = id;
            productCategory.CategoryOrder = cateOrder;
            productCategory.CategoryDecription = aNode.InnerText.Trim();
            productCategory.CreatedDate = DateTime.Now;
            productCategory.ModifiedDate = DateTime.Now;
            productCategory.CreatedBy = null;
            productCategory.ModifiedBy = null;
            productCategory.Code = aNode.GetAttributeValue("href", null).Trim('/');
            productCategory.ParentId = parentId;
            return productCategory;
        }
    }
}
