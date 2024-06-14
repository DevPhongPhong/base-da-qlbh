using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Common;
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

        public HomeController(ILogger<HomeController> logger, IKaaflyService kaaflyService, IProductService productService, INewsService newsService, ICommonService commonService)
        {
            _logger = logger;
            this.kaaflyService = kaaflyService;
            this.productService = productService;
            this.newsService = newsService;
            this.commonService = commonService;
        }

        public IActionResult Index()
        {
            //GetDataMenu();
            //ViewBag.ListHomeHot = kaaflyService.GetListProductByHomeHot(true, true, 10);
            //ViewBag.ListHome = kaaflyService.GetListProductByHomeHot(true, false, 10);
            //ViewBag.NewsHomeHot = newsService.GetRandomHotNewses(3);
            //ViewBag.HotCategoryProduct = productService.GetListProductCategoryByHomeHot(true, true, 10);
            //ViewBag.ProductCategoryShowOnHome = productService.GetAllProductCategoryShowOnHome(true, true, 5);
            GetDataMenu();
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
            request.Size = 12;
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
            ViewBag.RelateCategories = productService.GetRelatedCate(id);
            return View();
        }
        [Route("product/details")]
        public IActionResult ProductDetails(int id)
        {
            GetDataMenu();

            var data = kaaflyService.GetProductViewModelById(id);
            if (data == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ProductDetail = data;
            return View(data);
        }
        [Route("product/getquickview")]
        public JsonResult GetQuickView(int id)
        {
            var data = kaaflyService.GetProductById(id);
            if (data == null)
                return Json(new { success = false, message = "Không tồn tại sản phẩm!" });
            return Json(new { success = true, data.Name, data.Price, data.IsPromote, data.PromotionPrice, data.MainImageLarge, data.SubDes, data.Quantity, data.Branch });
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
        public IActionResult _MainMenu()
        {
            return PartialView();
        }

        private void GetDataMenu()
        {
            TempData["productmenu"] = commonService.GetListProductCategory().OrderBy(x => x.CategoryOrder).ToList();
            TempData["newsmenu"] = commonService.GetListCategoryNews().OrderBy(x => x.CategoryOrder).ToList();
        }
    }
}
