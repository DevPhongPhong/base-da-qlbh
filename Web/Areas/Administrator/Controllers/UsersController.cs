using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UsersController : BaseController
    {
        private readonly ICommonService _commonService;
        public UsersController(ICommonService commonService)
        {
            this._commonService = commonService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var listData = _commonService.GetUsers();
            return View(listData);
        }
        [HttpGet]
        public IActionResult Create()
        {
            SetComboboxRole();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Users model)
        {
            SetComboboxRole();
            try
            {
                if (ModelState.IsValid)
                {
                    var check = _commonService.CheckExistUserName(model.Username);
                    if (check)
                    {
                        SetAlert("error", "Đã tồn tại username: " + model.Username + "trong hệ thống!");
                        return View(model);
                    }
                    if (model.Password == null)
                    {
                        model.Password = "123456";
                    }                    
                    model.IsActive = true;
                    model.CreatedBy = this.HttpContext.Session.GetString("user");
                    model.CreatedDate = DateTime.Now;
                    var res = _commonService.InsertOrUpdateUser(model);
                    if (res)
                    {
                        SetAlert("success", "Thêm mới dữ liệu thành công!");
                        return RedirectToAction("Index", "Users");
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
        public IActionResult Edit(Guid id)
        {
            SetComboboxRole();
            var data = _commonService.GetUser(id);
            if (data == null)
            {
                SetAlert("error", "Không tìm thấy dữ liệu!");
                return RedirectToAction("Index", "Users");
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Users model)
        {
            SetComboboxRole();
            try
            {
                if (ModelState.IsValid)
                {
                    model.ModifiedBy = this.HttpContext.Session.GetString("user");
                    model.ModifiedDate = DateTime.Now;
                    var res = _commonService.InsertOrUpdateUser(model);
                    if (res)
                    {
                        SetAlert("success", "Cập nhật dữ liệu thành công!");
                        return RedirectToAction("Index", "Users");
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
        public IActionResult Delete(Guid id)
        {
            try
            {
                var res = _commonService.DeleteUser(id);
                if (res)
                {
                    SetAlert("success", "Xóa dữ liệu thành công!");
                    return RedirectToAction("Index", "Users");
                }
                return RedirectToAction("Index", "Users");
            }
            catch (Exception e)
            {
                SetAlert("error", "Có lỗi xảy ra:" + e.Message);
                return RedirectToAction("Index", "Users");
            }
        }
        #region Private Function
        private void SetComboboxRole()
        {
            ViewBag.ListRole = _commonService.getListRole().Select(p => new SelectListItem
            {
                Text = p.RoleName,
                Value = p.Id.ToString()
            }).ToList();
        }
        #endregion
    }
}
