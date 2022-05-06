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
    public class AccountsController : BaseController
    {
        private readonly ICommonService _commonService;
        public AccountsController(ICommonService commonService)
        {
            this._commonService = commonService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var listData = _commonService.GetAccounts();
            return View(listData);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Accounts model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var check = _commonService.CheckExistAccountUserName(model.Username);
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
                    model.CreateBy = this.HttpContext.Session.GetString("user");
                    model.CreateDate = DateTime.Now;
                    var res = _commonService.InsertOrUpdateAccount(model);
                    if (res)
                    {
                        SetAlert("success", "Thêm mới dữ liệu thành công!");
                        return RedirectToAction("Index", "Accounts");
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
            var data = _commonService.GetAccount(id);
            if (data == null)
            {
                SetAlert("error", "Không tìm thấy dữ liệu!");
                return RedirectToAction("Index", "Accounts");
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Accounts model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ModifiedBy = this.HttpContext.Session.GetString("user");
                    model.ModifiedDate = DateTime.Now;
                    var res = _commonService.InsertOrUpdateAccount(model);
                    if (res)
                    {
                        SetAlert("success", "Cập nhật dữ liệu thành công!");
                        return RedirectToAction("Index", "Accounts");
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
                var res = _commonService.DeleteAccount(id);
                if (res)
                {
                    SetAlert("success", "Xóa dữ liệu thành công!");
                    return RedirectToAction("Index", "Accounts");
                }
                return RedirectToAction("Index", "Accounts");
            }
            catch (Exception e)
            {
                SetAlert("error", "Có lỗi xảy ra:" + e.Message);
                return RedirectToAction("Index", "Accounts");
            }
        }

        public IActionResult ChangeStatus(Guid id)
        {
            try
            {
                var res = _commonService.ChangeStatus(id);
                return Ok(new { id = id, isactive = res.ToString() });
            }
            catch (Exception e)
            {
                return BadRequest( e.Message);
            }

        }
    }
}
