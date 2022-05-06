using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Common;
using Services.FromCustomer;
using Services.Kaafly;
using Services.News;
using Services.Product;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : WebBaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IKaaflyService kaaflyService;
        private IProductService productService;
        private INewsService newsService;
        private ICommonService commonService;
        private IFromCustomerService fromCustomerService;

        public HomeController(ILogger<HomeController> logger, IKaaflyService kaaflyService, IProductService productService, INewsService newsService, ICommonService commonService, IFromCustomerService _fromCustomerService)
        {
            _logger = logger;
            this.kaaflyService = kaaflyService;
            this.productService = productService;
            this.newsService = newsService;
            this.commonService = commonService;
            this.fromCustomerService = _fromCustomerService;
        }

        public IActionResult Index()
        {
            GetDataMenu();
            ViewBag.ListHomeHot = kaaflyService.GetListProductByHomeHot(true, true, 10);
            ViewBag.ListHome = kaaflyService.GetListProductByHomeHot(true, false, 10);
            ViewBag.NewsHomeHot = newsService.GetRandomHotNewses(3);
            ViewBag.HotCategoryProduct = productService.GetListProductCategoryByHomeHot(true, true, 10);
            ViewBag.ProductCategoryShowOnHome = productService.GetAllProductCategoryShowOnHome(true, true, 5);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("gioi-thieu")]
        public IActionResult About()
        {
            GetDataMenu();
            return View();
        }

        [Route("product")]
        public IActionResult Product(int id, int page, string order)
        {
            GetDataMenu();

            RequestHomeViewModel request = new RequestHomeViewModel();
            request.Offset = page;
            request.categoryId = id;
            request.Size = 9;
            var data = kaaflyService.GetListProductByCategoryId(request);
            if (order == "date")
            {
                data.Data = data.Data.OrderByDescending(x => x.CreatedDate).ToList();
            }
            else if (order == "date_desc")
            {
                data.Data = data.Data.OrderBy(x => x.CreatedDate).ToList();
            }
            else if (order == "price")
            {
                data.Data = data.Data.OrderBy(x => x.Price).ToList();
            }
            else if (order == "price_desc")
            {
                data.Data = data.Data.OrderByDescending(x => x.Price).ToList();
            }
            else if (order == "abc")
            {
                data.Data = data.Data.OrderBy(x => x.Name).ToList();
            }
            else if (order == "abc_desc")
            {
                data.Data = data.Data.OrderByDescending(x => x.Name).ToList();
            }
            else if (order == "best_sell")
            {
                data.Data = data.Data.OrderByDescending(x => x.IsPromote && x.IsHot).ToList();
            }
            ViewBag.ListProductByCategory = data;
            ViewBag.CurrentOrder = order;
            ViewBag.CurrentCategoryName = (id != 0) ? kaaflyService.GetCategoryById(id)?.CategoryName : "Tất cả sản phẩm";
            ViewBag.RandomProductCategory = commonService.GetRandomProductCategory(5);
            return View();
        }
        [Route("product/details")]
        public IActionResult ProductDetails(int id, int color, int length, int quantity)
        {
            GetDataMenu();

            var data = kaaflyService.GetProductById(id);
            if (data == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ProductDetail = kaaflyService.GetProductById(id);
            ViewBag.ChooseColor = color;
            ViewBag.ChooseLength = length;
            ViewBag.ChooseProduct = id;
            ViewBag.ChooseQuantity = quantity;
            ViewBag.ListFeedback = fromCustomerService.GetProductComments().Where(x => x.ProductID == id && x.Status == true && x.ShowOnHome == true).OrderByDescending(x => x.CreateDate).Take(3).ToList();
            return View(data);
        }

        [Route("tin-tuc")]
        public IActionResult News(int? id, int? page, string order)
        {
            ViewBag.ListRandomCategoryNews = commonService.GetRandomCategoryNews(4);
            ViewBag.ListHotNewses = newsService.GetRandomHotNewses(4);
            ViewBag.ListRecentNews = newsService.GetRecentNewses(3);
            GetDataMenu();

            RequestHomeViewModel request = new RequestHomeViewModel();
            request.Offset = page;
            request.categoryId = id;
            request.Size = 5;
            var data = newsService.GetHomeNewses(request);
            if (order == "new")
            {
                data.Data = data.Data.OrderByDescending(x => x.CreatedDate).ToList();
            }
            else if (order == "new_desc")
            {
                data.Data = data.Data.OrderBy(x => x.CreatedDate).ToList();
            }
            else if (order == "abc")
            {
                data.Data = data.Data.OrderBy(x => x.Title).ToList();
            }
            else if (order == "abc_desc")
            {
                data.Data = data.Data.OrderByDescending(x => x.Title).ToList();
            }
            ViewBag.ListMainNews = data;
            ViewBag.ListRandomCategoryNews = commonService.GetRandomCategoryNews(4);
            ViewBag.ListHotNewses = newsService.GetRandomHotNewses(4);
            ViewBag.ListRecentNews = newsService.GetRecentNewses(5);
            int checkId = id != null ? (int)id : 0;
            ViewBag.CurrentCategory = commonService.GetCategoryNews(checkId) != null ? commonService.GetCategoryNews(checkId).CategoryName : "Tất cả danh mục";
            ViewBag.CurrentOrder = order;
            return View();
        }
        [Route("news/details")]
        public IActionResult NewsDetail(int id)
        {
            ViewBag.ListRandomCategoryNews = commonService.GetRandomCategoryNews(4);
            ViewBag.ListHotNewses = newsService.GetRandomHotNewses(4);
            ViewBag.ListRecentNews = newsService.GetRecentNewses(3);
            ViewBag.ListFeedback = fromCustomerService.GetNewsComments().Where(x => x.NewsID == id && x.Status == true && x.ShowOnHome==true).OrderByDescending(x=>x.CreateDate).Take(3).ToList();
            GetDataMenu();

            var data = newsService.GetNews(id);
            if (data == null)
            {
                TempData["StrErr"] = "Không tìm thấy tin tức!";
                return RedirectToAction("Index", "Home");
            }
            return View(data);
        }

        //Search Products and News
        [HttpGet]
        [Route("tim-kiem")]
        public IActionResult Search(int page, string order, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ListRandomCategoryNews = commonService.GetRandomCategoryNews(4);
            ViewBag.ListHotNewses = newsService.GetRandomHotNewses(4);
            ViewBag.ListRecentNews = newsService.GetRecentNewses(3);
            GetDataMenu();
            if (keyword != null)
            {
                keyword = keyword.TrimEnd();
                keyword = keyword.ToLower();
            }

            GetDataMenu();

            RequestSearchModel request = new RequestSearchModel();
            request.Offset = page;
            request.Size = 9;
            request.Order = order;
            request.KeyWord = keyword;
            var data = kaaflyService.GetListProductBySearchKeyWord(request);

            ViewBag.ListProductBySearchKeyWord = data;
            ViewBag.CurrentOrder = order;
            ViewBag.RandomProductCategory = commonService.GetRandomProductCategory(5);
            ViewBag.CurrentKeyword = keyword;
            return View();
        }
        [Route("lien-he")]
        [HttpGet]
        public IActionResult Contact()
        {
            GetDataMenu();
            return View();
        }
        [Route("lien-he")]
        [HttpPost]
        public IActionResult Contact(SendContactModel model)
        {
            try
            {
                var feedback = new Feedback
                {
                    Email = model.email,
                    Name = model.name,
                    Message = model.description,
                    PhoneNumber = model.phone,
                    Subject = model.subject
                };
                feedback.Type = model.type;
                if (model.type == 2) feedback.ProductID = model.objID;
                if (model.type == 3) feedback.NewsID = model.objID;
                feedback.CreateDate = DateTime.Now;
                feedback.Status = true;
                feedback.ShowOnHome = true;
                feedback.Avatar = "/Upload/user-avatar.png";
                var status = fromCustomerService.AddFeedback(feedback);
                if (status)
                {
                    TempData["sentContact"] = "success";
                    return Redirect(model.url);
                }

                else
                {
                    TempData["sentContact"] = "error";
                    return Redirect(model.url);
                }
            }
            catch (Exception ex)
            {
                TempData["sentContact"] = "error";
                return Redirect(model.url);
            }

        }
        public IActionResult _MainMenu()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Subscribe(string email)
        {
            try
            {
                var sub = new SubscribeEmail { Email = email, CreateDate = DateTime.Now };
                return Json(new { status = fromCustomerService.AddSubscribeEmail(sub) });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }
        private void GetDataMenu()
        {
            TempData["productmenu"] = commonService.GetListProductCategory().OrderBy(x => x.CategoryOrder).ToList();
            TempData["newsmenu"] = commonService.GetListCategoryNews().OrderBy(x => x.CategoryOrder).ToList();
        }
    }
}
