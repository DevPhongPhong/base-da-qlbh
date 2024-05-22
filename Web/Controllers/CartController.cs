using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Services.Common;
using Services.Kaafly;
using Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ultilities;
using Ultilities.Models;
using Web.Models;
namespace Web.Controllers
{
    public class CartController : WebBaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKaaflyService kaaflyService;
        private readonly IProductService productService;
        private readonly ICommonService commonService;
        private readonly IConfiguration iConfig;
        private readonly IHostingEnvironment hostingEnvironment;

        public CartController(ILogger<HomeController> logger, IKaaflyService kaaflyService, IProductService productService, ICommonService commonService, IConfiguration iConfig, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            this.kaaflyService = kaaflyService;
            this.productService = productService;
            this.commonService = commonService;
            this.iConfig = iConfig;
            this.hostingEnvironment = hostingEnvironment;
        }
        [Route("cart")]
        public IActionResult Index()
        {
            GetDataMenu();
            var list = GetCartInSession();
            ViewBag.ListProductsInCart = list;
            return View();
        }
        [Route("payment")]
        [HttpGet]
        public IActionResult Payment()
        {
            var list = GetCartInSession();
            if (list?.Count() == 0)
            {
                TempData["StrErr"] = "Cart is empty!";
                return RedirectToAction("Index", "Home");
            }
            GetDataMenu();
            ViewBag.ListProductsInCart = list;
            var paymentData = new OrderRequestViewModel();
            var userData = GetMemberData();
            if (userData != null)
            {
                paymentData.CustomerAddress = userData.Address;
                paymentData.CustomerEmail = userData.Email;
                paymentData.CustomerFullName = userData.FullName;
                paymentData.CustomerPhone = userData.Phone;
            }
            return View(paymentData);
        }
        [Route("payment")]
        [HttpPost]
        public IActionResult Payment(OrderRequestViewModel model)
        {
            try
            {
                var list = GetCartInSession();
                ViewBag.ListProductsInCart = list;
                if (list?.Count() == 0)
                {
                    TempData["StrErr"] = "Cart is empty!";
                    return RedirectToAction("Index", "Home");
                }
                model.ProductsOrder = new List<ProductOrder>();
                model.TotalPrice = 0;
                foreach (var item in list)
                {
                    if (!productService.CheckQuantityProductOrder(item.Product.Id, item.Quantity))
                    {
                        TempData["StrErr"] = "Có lỗi xảy ra: " + "Sản phẩm " + item.Product.Name + " không có đủ hàng trong kho" + "!";
                        return RedirectToAction("Index", "Cart");
                    };
                    var productOrder = new ProductOrder();
                    productOrder.ProductId = item.Product.Id;
                    productOrder.ProductName = item.Product.Name;
                    productOrder.ProductImage = item.Product.MainImageLarge;
                    productOrder.ProductPrice = item.Product.IsPromote ? item.Product.PromotionPrice : item.Product.Price;
                    productOrder.Quantity = item.Quantity;
                    model.ProductsOrder.Add(productOrder);
                    model.TotalPrice += productOrder.ProductPrice;
                }
                var order = kaaflyService.OrderRequest(model);
                if (order != null)
                {
                    ClearCart();
                    //SendEmailToCustomer(order);
                    //SendEmailToShop(order);
                    return RedirectToAction("TrackingOrderReceived", "Cart", new { orderCode = order.OrderCode, email = order.CustomerEmail });
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                GetDataMenu();
                TempData["StrErr"] = "Có lỗi xảy ra: " + e.Message + "!";
                return View(model);
            }
        }
        [Route("add-to-cart")]
        public ActionResult AddItem(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                TempData["StrErr"] = "Quantity is not valid!";
                return RedirectToAction("ProductDetails", "Home", new { id = productId });
            }
            if (productId <= 0)
            {
                TempData["StrErr"] = "Product is not valid!";
                return RedirectToAction("ProductDetails", "Home", new { id = productId });
            }
            var product = productService.GetProduct(productId);
            if (product == null) return RedirectToAction("Index", "Home");
            var cart = HttpContext.Session.GetString("cart");
            // Giỏ hàng rỗng
            if (cart != null)
            {
                var list = JsonConvert.DeserializeObject<List<CartItem>>(cart);
                // Đã có hàng
                if (list.Exists(x => x.Product.Id == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.Id == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                string jsonData = JsonConvert.SerializeObject(list);
                HttpContext.Session.SetString("cart", jsonData);
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                string jsonData = JsonConvert.SerializeObject(list);
                HttpContext.Session.SetString("cart", jsonData);
            }
            return RedirectToAction("Index");
        }
        public IActionResult AddToCart(int productId)
        {
            try
            {
                var product = productService.GetProduct(productId);
                if (product == null) return Json(new { response = "error", message = "product is not exsit" });
                if (product.Quantity <= 0 || product.Quantity == null) return Json(new { response = "error", message = "Sản phẩm đã hết hàng!" });
                var cart = HttpContext.Session.GetString("cart");
                // Giỏ hàng rỗng
                if (cart != null && cart != "[]")
                {
                    var list = JsonConvert.DeserializeObject<List<CartItem>>(cart);
                    // Đã có hàng
                    if (list.Exists(x => x.Product.Id == productId))
                    {
                        var obj = list.First(x => x.Product.Id == productId);
                        obj.Quantity += 1;
                        //Gán vào session
                        string jsonData = JsonConvert.SerializeObject(list);
                        HttpContext.Session.SetString("cart", jsonData);
                        return Json(new
                        {
                            response = "added",
                            type = "edit",
                            productId = obj.Product.Id,
                            quantity = obj.Quantity,
                            totalPrice = TotalPrice().GetValueOrDefault(0).ToString("N0") + " đ"
                        });
                    }
                    else
                    {
                        //tạo mới đối tượng cart item
                        var item = new CartItem();
                        item.Product = product;
                        item.Quantity = 1;
                        list.Add(item);
                        //Gán vào session
                        string jsonData = JsonConvert.SerializeObject(list);
                        HttpContext.Session.SetString("cart", jsonData);
                        return Json(new
                        {
                            response = "added",
                            type = "newItem",
                            productId = item.Product.Id,
                            productName = item.Product.Name,
                            price = (item.Product.PromotionPrice.HasValue ? item.Product.PromotionPrice : item.Product.Price).GetValueOrDefault(0).ToString("N0") + " đ",
                            productImage = item.Product.MainImageThumb,
                            totalPrice = TotalPrice().GetValueOrDefault(0).ToString("N0") + " đ",
                            countCI = list.Count()
                        });
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = 1;
                    var list = new List<CartItem>();
                    list.Add(item);
                    //Gán vào session
                    string jsonData = JsonConvert.SerializeObject(list);
                    HttpContext.Session.SetString("cart", jsonData);
                    return Json(new
                    {
                        response = "added",
                        type = "newCart",
                        productId = item.Product.Id,
                        productName = item.Product.Name,
                        price = (item.Product.PromotionPrice.HasValue ? item.Product.PromotionPrice : item.Product.Price).GetValueOrDefault(0).ToString("N0") + " đ",
                        productImage = item.Product.MainImageThumb,
                        totalPrice = TotalPrice().GetValueOrDefault(0).ToString("N0") + " đ",
                        countCI = list.Count()
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new { response = "error", message = ex.Message });
            }

        }
        public JsonResult DeleteAll()
        {
            HttpContext.Session.Remove("cart");
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var cart = HttpContext.Session.GetString("cart");
            var sessionCart = JsonConvert.DeserializeObject<List<CartItem>>(cart);
            sessionCart.RemoveAll(x => x.Product.Id == id);
            string newJson = JsonConvert.SerializeObject(sessionCart);
            HttpContext.Session.SetString("cart", newJson);
            return Json(new
            {
                status = true
            });
        }
        public JsonResult UpdateItem(int id, int quantity, string sumPrice, string allPrice)
        {
            try
            {
                var SumPrice = decimal.Parse(sumPrice);
                var AllPrice = decimal.Parse(allPrice);

                string oldJson = HttpContext.Session.GetString("cart");
                var oldData = JsonConvert.DeserializeObject<List<CartItem>>(oldJson);
                var item = oldData.FirstOrDefault(x => x.Product.Id == id);

                var oldQuantity = item.Quantity;

                SumPrice += (quantity - oldQuantity) * (item.Product.IsPromote ? item.Product.PromotionPrice.GetValueOrDefault(0) : item.Product.Price.GetValueOrDefault(0));
                AllPrice += (quantity - oldQuantity) * (item.Product.IsPromote ? item.Product.PromotionPrice.GetValueOrDefault(0) : item.Product.Price.GetValueOrDefault(0));

                item.Quantity = quantity;
                string newJson = JsonConvert.SerializeObject(oldData);

                HttpContext.Session.SetString("cart", newJson);
                return Json(new
                {
                    status = true,
                    sumPrice = SumPrice.ToString("N0"),
                    allPrice = AllPrice.ToString("N0")
                });
            }
            catch (Exception ex)
            {
                return Json(new { status = ex.Message });
            }
        }

        public JsonResult Update(string cartModel)
        {
            var newData = JsonConvert.DeserializeObject<List<CartItem>>(cartModel);
            string oldJson = HttpContext.Session.GetString("cart");
            var oldData = JsonConvert.DeserializeObject<List<CartItem>>(oldJson);

            foreach (var item in oldData)
            {
                var jsonItem = newData.SingleOrDefault(x => x.Product.Id == item.Product.Id);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            string newJson = JsonConvert.SerializeObject(oldData);
            HttpContext.Session.SetString("cart", newJson);
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public IActionResult OrderRequest(OrderRequestViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                string res = "";
                var check = kaaflyService.OrderRequest(model);
                if (check != null)
                {
                    return Ok(res);
                }
                else
                {
                    return Ok("Đăng ký thất bại, vui lòng liên hệ với quản trị viên!");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        [Route("tra-cuu-don-hang")]
        [HttpGet]
        public IActionResult SearchOrderReceived()
        {
            try
            {
                GetDataMenu();
                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return Redirect("/");
            }

        }
        [Route("danh-sach-don-hang")]
        [HttpGet]
        public IActionResult ListOrderReceived()
        {
            try
            {
                var obj = GetMemberData();
                if (obj != null)
                {
                    GetDataMenu();
                    var list = kaaflyService.ListOrderReceivedOfMemberByEmail(obj.Email);
                    TempData["phoneNumber"] = obj.Phone;
                    TempData["email"] = obj.Email;
                    return View(list);
                }
                else return RedirectToAction("SearchOrderReceived", "Cart");
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return View();
            }

        }
        [HttpGet]
        [Route("don-hang")]
        public IActionResult TrackingOrderReceived(string orderCode, string email)
        {
            try
            {
                var a = GetMemberData();
                if (a != null) TempData["onSession"] = "true";
                if (!string.IsNullOrEmpty(orderCode))
                {
                    var order = kaaflyService.GetOrderReceivedByOrderCodeAndEmail(orderCode, email);
                    GetDataMenu();
                    return View(order);
                }
                else
                {
                    TempData["error"] = "Mã đơn hàng không được trống!";
                    return RedirectToAction("SearchOrderReceived", "Cart");
                }
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("SearchOrderReceived", "Cart");
            }
        }
        #region Private Functions
        private Accounts GetMemberData()
        {
            var member = HttpContext.Session.GetString("member");
            var data = member != null ? JsonConvert.DeserializeObject<Accounts>(member) : null;
            return data;
        }
        private List<CartItem> GetCartInSession()
        {
            try
            {
                var cartSession = HttpContext.Session.GetString("cart");
                var list = cartSession != null ? JsonConvert.DeserializeObject<List<CartItem>>(cartSession) : new List<CartItem>();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove("cart");
        }
        private void GetDataMenu()
        {
            TempData["productmenu"] = commonService.GetListProductCategory().OrderBy(x => x.CategoryOrder).ToList();
            TempData["newsmenu"] = commonService.GetListCategoryNews().OrderBy(x => x.CategoryOrder).ToList();
        }
        private async void SendEmailToCustomer(OrderResponseViewModel model)
        {
            try
            {
                var gmailSmtp = new GmailSmtp();

                gmailSmtp.enableSSL = bool.Parse(iConfig.GetSection("GmailSetting").GetSection("EnableSSL").Value);
                gmailSmtp.password = iConfig.GetSection("GmailSetting").GetSection("Password").Value;
                gmailSmtp.portNumber = int.Parse(iConfig.GetSection("GmailSetting").GetSection("PortNumber").Value);
                gmailSmtp.sender = iConfig.GetSection("GmailSetting").GetSection("Username").Value;
                gmailSmtp.smtpAddress = iConfig.GetSection("GmailSetting").GetSection("SmtpAddress").Value;
                gmailSmtp.useDefaultCredentials = bool.Parse(iConfig.GetSection("GmailSetting").GetSection("UseDefaultCredentials").Value);

                var mailData = new Email();

                string webRootPath = "\\wwwroot\\template\\neworderemail.html";
                string contentRootPath = hostingEnvironment.ContentRootPath;
                string templatePath = contentRootPath + webRootPath;

                string htmlBody = System.IO.File.ReadAllText(templatePath);

                htmlBody = htmlBody.Replace("{{CustomerName}}", model.CustomerFullName);
                htmlBody = htmlBody.Replace("{{CustomerPhone}}", model.CustomerPhone);
                htmlBody = htmlBody.Replace("{{CustomerEmail}}", model.CustomerEmail);
                htmlBody = htmlBody.Replace("{{CustomerAddress}}", model.CustomerAddress);
                htmlBody = htmlBody.Replace("{{CustomerNote}}", model.CustomerNote);
                htmlBody = htmlBody.Replace("{{OrderCode}}", model.OrderCode);
                htmlBody = htmlBody.Replace("{{PaymentTypeName}}", "Người nhận thanh toán");
                htmlBody = htmlBody.Replace("{{ShippingFee}}", "Miễn phí");
                htmlBody = htmlBody.Replace("{{ProductPrice}}", model.TotalPrice.ToStringMoney());
                htmlBody = htmlBody.Replace("{{TotalPrice}}", model.TotalPrice.ToStringMoney());

                var htmlListProductsOrder = "";
                foreach (var item in model.ProductsOrder)
                {
                    htmlListProductsOrder +=
                        "<tr>" +
                        "<td align='left' style='padding: 3px 9px' valign='top'>" +
                        " <span>" + item.ProductName + "</span><br>" +
                        "</td>" +
                        "<td align='left' style='padding: 3px 9px' valign='top'><span>" + item.ProductPrice.ToStringMoney() + " đ</span></td>" +
                        "<td align='left' style='padding: 3px 9px' valign='top'>" + item.Quantity + "</td>" +
                        "<td align='right' style='padding: 3px 9px' valign='top'><span>" + (item.ProductPrice * item.Quantity).ToStringMoney() + " đ</span></td>" +
                        "</tr>";
                }

                htmlBody = htmlBody.Replace("{{ListProductOrder}}", htmlListProductsOrder);

                mailData.from = iConfig.GetSection("GmailSetting").GetSection("Username").Value;
                mailData.toList = new List<string>();
                mailData.toList.Add(model.CustomerEmail);
                mailData.isBodyHtml = true;
                mailData.subject = "MinaShop đã xác nhận đơn hàng của bạn";
                mailData.body = htmlBody;
                mailData.ccList = null;

                gmailSmtp.EmailData = mailData;

                await Task.Run(() => EmailHelper.SendGMail(gmailSmtp));
            }
            catch (Exception e)
            {
                return;
            }
        }
        private async void SendEmailToShop(OrderResponseViewModel model)
        {
            try
            {
                var gmailSmtp = new GmailSmtp();

                gmailSmtp.enableSSL = bool.Parse(iConfig.GetSection("GmailSetting").GetSection("EnableSSL").Value);
                gmailSmtp.password = iConfig.GetSection("GmailSetting").GetSection("Password").Value;
                gmailSmtp.portNumber = int.Parse(iConfig.GetSection("GmailSetting").GetSection("PortNumber").Value);
                gmailSmtp.sender = iConfig.GetSection("GmailSetting").GetSection("Username").Value;
                gmailSmtp.smtpAddress = iConfig.GetSection("GmailSetting").GetSection("SmtpAddress").Value;
                gmailSmtp.useDefaultCredentials = bool.Parse(iConfig.GetSection("GmailSetting").GetSection("UseDefaultCredentials").Value);

                var mailData = new Email();

                var htmlBody = "<p>Có 1 đơn hàng mới đặt từ website atzshop.vn</p>"
                                + "<p>Mã đơn hàng: <b>" + model.OrderCode + "</b></p>"
                                + "<p>Truy cập https://atzshop.vn/admin bằng tài khoản hệ thống bán hàng để thực hiện đơn hàng</p>";

                mailData.from = iConfig.GetSection("GmailSetting").GetSection("Username").Value;
                mailData.toList = new List<string>();
                mailData.toList.Add(iConfig.GetSection("GmailSetting").GetSection("ShopEmail").Value);
                mailData.isBodyHtml = true;
                mailData.subject = "Thông báo đơn hàng mới từ website Sanfarm.vn";
                mailData.body = htmlBody;
                mailData.ccList = null;

                gmailSmtp.EmailData = mailData;

                await Task.Run(() => EmailHelper.SendGMail(gmailSmtp));
            }
            catch (Exception)
            {
                return;
            }
        }
        private decimal? TotalPrice()
        {
            decimal? res = 0;
            var cart = HttpContext.Session.GetString("cart");
            var list = JsonConvert.DeserializeObject<List<CartItem>>(cart);
            foreach (var item in list)
            {
                res += (item.Product.PromotionPrice.HasValue ? item.Product.PromotionPrice : item.Product.Price) * item.Quantity;
            }
            return res;
        }
        #endregion
    }
}
