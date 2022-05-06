using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("admin")]
    public class DefaultController : BaseController
    {
        private readonly ICommonService _commonService;
        public DefaultController(ICommonService commonService)
        {
            this._commonService = commonService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [Route("change-password")]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                model.username = TempData["user"].ToString();
                if (model.newPassword != model.reNewPassword)
                {
                    ModelState.AddModelError("newPassword", "2 mật khẩu không khớp!");
                    ModelState.AddModelError("reNewPassword", "2 mật khẩu không khớp!");
                    return View(model);
                }
                if (!_commonService.CheckPassWord(model))
                {
                    ModelState.AddModelError("oldPassword", "Mật khẩu cũ không đúng!");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    var res = _commonService.ChangePassword(model);
                    if (res)
                    {
                        SetAlert("success", "Đổi mật khẩu thành công!");
                        return RedirectToAction("Index", "Default");
                    }
                    SetAlert("error", "Cập nhật dữ liệu thất bại!");
                    return View(model);
                }
                return View(model);
            }
            catch (Exception e)
            {
                SetAlert("error", "Lỗi hệ thống: " + e.Message);
                return View(model);
            }
        }
    }
}
