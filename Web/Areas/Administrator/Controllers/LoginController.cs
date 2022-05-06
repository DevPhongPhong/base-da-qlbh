using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [HttpPost]
        [Route("~/login")]
        public IActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
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
