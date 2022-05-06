using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Services.Common;
using Services.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ReportController : BaseController
    {
        private readonly ICommonService commonService;
        private readonly IOrderService orderService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private IConfiguration iConfig;
        public ReportController(ICommonService commonService, IOrderService newsService, IWebHostEnvironment hostingEnvironment, IConfiguration iConfig)
        {
            this.commonService = commonService;
            this.orderService = newsService;
            this.hostingEnvironment = hostingEnvironment;
            this.iConfig = iConfig;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BaoCaoNgay(DateTime ngay)
        {
            if (ngay == DateTime.MinValue)
            {
                ngay = DateTime.Now;
            }

            ViewBag.Filter = ngay;
            return View();
        }
        public IActionResult BaoCaoThang(DateTime ngay)
        {
            if (ngay == DateTime.MinValue)
            {
                ngay = DateTime.Now;
            }

            ViewBag.Filter = ngay;
            return View();
        }
        public IActionResult BaoCaoNam(int nam)
        {
            if (nam == 0)
            {
                nam = DateTime.Now.Year;
            }
            ViewBag.Filter = nam;
            return View();
        }
        public IActionResult GetDataBaoCaoNam(int nam)
        {
            if(nam == null || nam == 0)
            {
                nam = DateTime.Now.Year;
            }
            var obj = orderService.GetDataBaoCaoNam(nam);
            return Ok(JsonSerializer.Serialize(obj));
        }
        public IActionResult GetDataBaoCaoThang(string ngay)
        {
            var req = Convert.ToDateTime(ngay);
            if (req == DateTime.MinValue)
            {
                req = DateTime.Now;
            }
            var obj = orderService.GetDataBaoCaoThang(req);
            return Ok(JsonSerializer.Serialize(obj));
        }
        public IActionResult GetDataBaoCaoNgay(string ngay)
        {
            var req = DateTime.Parse(ngay);
            if (req == DateTime.MinValue)
            {
                req = DateTime.Now;
            }
            var obj = orderService.GetDataBaoCaoNgay(req);
            return Ok(JsonSerializer.Serialize(obj));
        }
    }
}
