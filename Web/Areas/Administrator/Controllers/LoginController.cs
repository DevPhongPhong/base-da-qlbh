using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Login;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ultilities;

namespace Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService _loginService)
        {
            this.loginService = _loginService;
        }
        [HttpGet]
        [Route("~/login")]
        public IActionResult Index()
        {
            return View();
        }
        private bool ValidatePasswordComplexity(string password)
        {
            const int minLength = 8;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{" + minLength + ",}$";
            Regex regex = new(pattern);
            return regex.IsMatch(password);
        }

        [HttpPost]
        [Route("~/login")]
        public IActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!ValidatePasswordComplexity(model.Password))
                {
                    ViewData["Error"] = "Mật khẩu phải có ít nhất 8 ký tự, chứa chữ cái thường, chữ hoa, số và ký tự đặc biệt!";
                    return View(model);
                }

                model.Password = EncryptExtensions.Hash(model.Password, null);
                var check = loginService.Login(model.Username, model.Password);
                if (check != null)
                {
                    // Set session
                    HttpContext.Session.SetString("user", model.Username);
                    HttpContext.Session.SetString("roleid", check.RoleId.ToString());
                    return RedirectToAction("Index", "Default");
                }
                else return View();
            }
            else return View();
        }
        [HttpGet]
        [Route("~/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
