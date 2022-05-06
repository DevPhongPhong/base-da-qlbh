using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Common;
using System;
using System.Linq;

namespace Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CategoryNewsController : BaseController
    {
        private readonly ICommonService _commonService;
        public CategoryNewsController(ICommonService commonService)
        {
            this._commonService = commonService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var listData = _commonService.GetListCategoryNews();
            return View(listData);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryNewsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = this.HttpContext.Session.GetString("user");
                    model.CreatedDate = DateTime.Now;
                    var res = _commonService.InsertOrUpdateCategoryNews(model);
                    if (res)
                    {
                        SetAlert("success", "Thêm mới dữ liệu thành công!");
                        return RedirectToAction("Index", "CategoryNews");
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
            var data = _commonService.GetCategoryNews(id);
            if (data == null)
            {
                SetAlert("error", "Không tìm thấy dữ liệu!");
                return RedirectToAction("Index", "CategoryNews");
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(CategoryNewsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ModifiedBy = this.HttpContext.Session.GetString("user");
                    model.ModifiedDate = DateTime.Now;
                    var res = _commonService.InsertOrUpdateCategoryNews(model);
                    if (res)
                    {
                        SetAlert("success", "Cập nhật dữ liệu thành công!");
                        return RedirectToAction("Index", "CategoryNews");
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
                if (!_commonService.CheckExistNews(id))
                {
                    var res = _commonService.DeleteCategoryNews(id);
                    if (res)
                    {
                        SetAlert("success", "Xóa dữ liệu thành công!");
                        return RedirectToAction("Index", "CategoryNews");
                    }
                    return RedirectToAction("Index", "CategoryNews");
                }
                SetAlert("error", "Không thể xóa đối tượng tồn tại dữ liệu!");
                return RedirectToAction("Index", "CategoryNews");
            }
            catch (Exception e)
            {
                SetAlert("error", "Có lỗi xảy ra:" + e.Message);
                return RedirectToAction("Index", "CategoryNews");
            }
        }
    }
}
