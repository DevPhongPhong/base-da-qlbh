using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using Services.Common;
using Services.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class OrderController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICommonService commonService;
        private readonly IOrderService orderService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private IConfiguration iConfig;
        public OrderController(ICommonService commonService, IOrderService newsService, IWebHostEnvironment hostingEnvironment, IConfiguration iConfig, IWebHostEnvironment webHostEnvironment)
        {
            this.commonService = commonService;
            this.orderService = newsService;
            this.hostingEnvironment = hostingEnvironment;
            this.iConfig = iConfig;
            this._webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int status)
        {
            if (status == 0)
            {
                ViewBag.TitleForm = "Danh sách đơn hàng";
            }
            else if (status == 1)
            {
                ViewBag.TitleForm = "Danh sách đơn hàng chờ xác nhận";
            }
            else if (status == 2)
            {
                ViewBag.TitleForm = "Danh sách đơn hàng chờ giao hàng";
            }
            else if (status == 3)
            {
                ViewBag.TitleForm = "Danh sách đơn hàng đang được giao";
            }
            else if (status == 4)
            {
                ViewBag.TitleForm = "Danh sách đơn hàng đã được giao";
            }
            else if (status == -1)
            {
                ViewBag.TitleForm = "Danh sách đơn hàng đã hủy";
            }
            else if (status == -2)
            {
                ViewBag.TitleForm = "Danh sách đơn hàng giao thất bại";
            }
            ViewBag.CurrentStatus = status;
            var data = orderService.GetOrders(status);
            data = data.OrderByDescending(x => x.CreatedDate).ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult ChangeStatus(int order, int status, int current)
        {
            if (status != 1 && status != 2 && status != 3 && status != 4 && status != -1 && status != -2)
            {
                SetAlert("error", "Thao tác không đúng!");
                return RedirectToAction("Index", "Order", new { status = current });
            }
            var change = orderService.ChangeStatus(order, status);
            if (change)
            {
                SetAlert("success", "Cập nhật trạng thái đơn thành công!");
                return RedirectToAction("Index", "Order", new { status = current });
            }
            else
            {
                SetAlert("error", "Có lỗi trong quá trình cập nhật dữ liệu!");
                return RedirectToAction("Index", "Order", new { status = current });
            }
        }
        public IActionResult Details(int id, int current)
        {
            var data = orderService.GetDetailsOrderByOrderId(id);
            if (data == null)
            {
                SetAlert("error", "Không tìm thấy dữ liệu!");
                return RedirectToAction("Index", "Order", new { status = 1 });
            }
            ViewBag.CurrentStatus = current;
            return View(data);
        }
        public JsonResult ExportExcel(int status)
        {
            string fileName = @"\excel\ListAllOrders-" + status.ToString()+"-" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss")+"-"+ Guid.NewGuid().ToString() + ".xlsx";
            try
            {
                ExcelPackage pkg = new ExcelPackage(new System.IO.FileInfo(_webHostEnvironment.WebRootPath + fileName));

                var ws = pkg.Workbook.Worksheets.Add("ListAllOrders-" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss"));
                int startRow = 2;
                int count = 1;
                var data = orderService.GetOrders(status).ToList();

                ws.Cells[1, 1].Value = "STT";
                ws.Cells[1, 2].Value = "Mã đơn";
                ws.Cells[1, 3].Value = "Tên khách hàng";
                ws.Cells[1, 4].Value = "Ngày đặt";
                ws.Cells[1, 5].Value = "Số điện thoại";
                ws.Cells[1, 6].Value = "Địa chỉ";
                ws.Cells[1, 7].Value = "Tổng tiền";
                ws.Cells[1, 8].Value = "Trạng thái đơn hàng";

                foreach (var item in data)
                {
                    ws.Cells[startRow, 1].Value = count++;
                    ws.Cells[startRow, 2].Value = item.OrderCode;
                    ws.Cells[startRow, 3].Value = item.CustomerFullName;
                    ws.Cells[startRow, 4].Value = item.CreatedDate.GetValueOrDefault().ToString("MM/dd/yyyy HH:mm:ss");
                    ws.Cells[startRow, 5].Value = item.CustomerPhone;
                    ws.Cells[startRow, 6].Value = item.CustomerAddress;
                    ws.Cells[startRow, 7].Value = item.TotalPrice;
                    ws.Cells[startRow, 8].Value = item.OrderStatusName;
                    startRow++;
                }
                ws.Cells.AutoFitColumns();
                pkg.Save();
                return Json(new { status = true, filePath = fileName });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }
    }
}
