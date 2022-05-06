using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("404")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("het-han-dung-thu")]
        public IActionResult Expired()
        {
            return View();
        }
    }
}
