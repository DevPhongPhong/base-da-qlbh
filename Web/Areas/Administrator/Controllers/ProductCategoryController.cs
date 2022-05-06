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
    public class ProductCategoryController : BaseController
    {
        private readonly ICommonService _commonService;
        public ProductCategoryController(ICommonService commonService)
        {
            this._commonService = commonService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var listData = _commonService.GetListProductCategory();
            return View(listData);
        }
        [HttpGet]
        public IActionResult Create()
        {
            SetComboboxParentProductCategory();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCategoryViewModel model)
        {
            SetComboboxParentProductCategory();
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = this.HttpContext.Session.GetString("user");
                    model.CreatedDate = DateTime.Now;
                    var res = _commonService.InsertOrUpdateProductCategory(model);
                    if (res)
                    {
                        SetAlert("success", "Thêm mới dữ liệu thành công!");
                        return RedirectToAction("Index", "ProductCategory");
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
            SetComboboxParentProductCategory(id);
            var data = _commonService.GetProductCategory(id);
            if (data == null)
            {
                SetAlert("error", "Không tìm thấy dữ liệu!");
                return RedirectToAction("Index", "ProductCategory");
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(ProductCategoryViewModel model)
        {
            SetComboboxParentProductCategory(model.Id);
            try
            {
                if (ModelState.IsValid)
                {
                    model.ModifiedBy = this.HttpContext.Session.GetString("user");
                    model.ModifiedDate = DateTime.Now;
                    var res = _commonService.InsertOrUpdateProductCategory(model);
                    if (res)
                    {
                        SetAlert("success", "Cập nhật dữ liệu thành công!");
                        return RedirectToAction("Index", "ProductCategory");
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
                if (_commonService.CheckCanDeleteProductCategory(id))
                {
                    var res = _commonService.DeleteProductCategory(id);
                    if (res)
                    {
                        SetAlert("success", "Xóa dữ liệu thành công!");
                        return RedirectToAction("Index", "ProductCategory");
                    }
                    return RedirectToAction("Index", "ProductCategory");
                }
                SetAlert("error", "Không thể xóa đối tượng tồn tại dữ liệu!");
                return RedirectToAction("Index", "ProductCategory");
            }
            catch (Exception e)
            {
                SetAlert("error", "Có lỗi xảy ra:" + e.Message);
                return RedirectToAction("Index", "ProductCategory");
            }
        }
        #region Private Function
        private void SetComboboxParentProductCategory(int? categoryId = null)
        {
            ViewBag.ProductCategories = _commonService.GetListDataProductCategory(categoryId).Select(p => new SelectListItem
            {
                Text = p.CategoryName,
                Value = p.Id.ToString()
            }).ToList();
        }
        #endregion
    }
}
