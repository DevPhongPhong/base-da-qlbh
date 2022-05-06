using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Services.Common;
using Services.News;
using System;
using System.Linq;
using Ultilities;

namespace Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class NewsController : BaseController
    {
        private readonly ICommonService _commonService;
        private readonly INewsService _newsService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private IConfiguration iConfig;
        public NewsController(ICommonService commonService, INewsService newsService, IWebHostEnvironment hostingEnvironment, IConfiguration iConfig)
        {
            this._commonService = commonService;
            this._newsService = newsService;
            this.hostingEnvironment = hostingEnvironment;
            this.iConfig = iConfig;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var listData = _newsService.GetListNews();
            return View(listData);
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            SetComboboxCategoryNews();
            var data = _newsService.GetNews(id);
            if (data == null)
            {
                SetAlert("error", "Không tìm thấy dữ liệu!");
                return RedirectToAction("Index", "News");
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            SetComboboxCategoryNews();
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewsViewModel model)
        {
            SetComboboxCategoryNews();
            try
            {
                if (model.NewsImageUpload != null)
                {
                    var isImage = FormFileExtensions.IsImage(model.NewsImageUpload);
                    if (isImage)
                    {
                        string webRootPath = iConfig.GetSection("CustomSetting").GetSection("ImageWebRootPath").Value;
                        string physicalPath = hostingEnvironment.WebRootPath + iConfig.GetSection("CustomSetting").GetSection("ImageUploadPhysicalPath").Value;

                        string originalPath = FileService.Upload(model.NewsImageUpload, physicalPath, webRootPath);
                        string scaledPath = FileService.ScaleImage(originalPath, model.NewsImageUpload);

                        model.LargeImage = originalPath;
                        model.ThumbImage = scaledPath;
                    }
                    else
                    {
                        ModelState.AddModelError("NewsImageUpload", "Tệp tải lên phải là hình ảnh!");
                        return View(model);
                    }
                }
                else
                {
                    model.LargeImage = "#";
                    model.ThumbImage = "#";
                }
                if (ModelState.IsValid)
                {
                    model.CreatedBy = this.HttpContext.Session.GetString("user");
                    model.CreatedDate = DateTime.Now;
                    model.PostedDate = DateTime.Now;
                    var res = _newsService.InsertOrUpdateNews(model);
                    if (res)
                    {
                        SetAlert("success", "Thêm mới dữ liệu thành công!");
                        return RedirectToAction("Index", "News");
                    }
                    SetAlert("error", "Cập nhật dữ liệu thất bại!");
                    return View(model);
                }
                return View(model);
            }
            catch (Exception e)
            {
                SetAlert("error", "Có lỗi xảy ra:" + e.Message);
                return View(model);
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            SetComboboxCategoryNews();
            var data = _newsService.GetNews(id);
            if (data == null)
            {
                SetAlert("error", "Không tìm thấy dữ liệu!");
                return RedirectToAction("Index", "News");
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(NewsViewModel model)
        {
            SetComboboxCategoryNews();
            try
            {
                if (model.NewsImageUpload != null)
                {
                    var isImage = FormFileExtensions.IsImage(model.NewsImageUpload);
                    if (isImage)
                    {
                        string webRootPath = iConfig.GetSection("CustomSetting").GetSection("ImageWebRootPath").Value;
                        string physicalPath = hostingEnvironment.WebRootPath + iConfig.GetSection("CustomSetting").GetSection("ImageUploadPhysicalPath").Value;

                        string originalPath = FileService.Upload(model.NewsImageUpload, physicalPath, webRootPath);
                        string scaledPath = FileService.ScaleImage(originalPath, model.NewsImageUpload);

                        model.LargeImage = originalPath;
                        model.ThumbImage = scaledPath;
                    }
                    else
                    {
                        ModelState.AddModelError("NewsImageUpload", "Tệp tải lên phải là hình ảnh!");
                        return View(model);
                    }
                }
                if (ModelState.IsValid)
                {
                    model.ModifiedBy = this.HttpContext.Session.GetString("user");
                    model.ModifiedDate = DateTime.Now;
                    var res = _newsService.InsertOrUpdateNews(model);
                    if (res)
                    {
                        SetAlert("success", "Cập nhật dữ liệu thành công!");
                        return RedirectToAction("Index", "News");
                    }
                    SetAlert("error", "Cập nhật dữ liệu thất bại!");
                    return View(model);
                }
                return View(model);
            }
            catch (Exception e)
            {
                SetAlert("error", "Có lỗi xảy ra:" + e.Message);
                return View(model);
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                var res = _newsService.DeleteNews(id);
                if (res)
                {
                    SetAlert("success", "Xóa dữ liệu thành công!");
                    return RedirectToAction("Index", "News");
                }
                return RedirectToAction("Index", "News");
            }
            catch (Exception e)
            {
                SetAlert("error", "Có lỗi xảy ra:" + e.Message);
                return RedirectToAction("Index", "News");
            }
        }
        #region Private Function
        private void SetComboboxCategoryNews()
        {
            ViewBag.CategoryNews = _commonService.GetListCategoryNews().Select(p => new SelectListItem
            {
                Text = p.CategoryName,
                Value = p.Id.ToString()
            }).ToList();
        }
        #endregion
    }
}
