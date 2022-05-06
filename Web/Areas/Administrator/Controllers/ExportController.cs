using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Services.Export;
using Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ExportController : BaseController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IProductService productService;
        private readonly IExportService exportService;

        public ExportController(IWebHostEnvironment _webHostEnvironment, IProductService _productService, IExportService _exportService)
        {
            this.webHostEnvironment = _webHostEnvironment;
            this.productService = _productService;
            this.exportService = _exportService;
        }

        public IActionResult Index(int page = 1, int size = 10)
        {
            var model = exportService.GetExportViewModels();
            ViewBag.CountRecord = model.Count();
            ViewBag.CurrentPage = page;
            ViewBag.CurrentSize = size;
            return View(model.Skip((page - 1) * size).Take(size));
        }
        public JsonResult ExportExcel()
        {
            string fileName = @"\excel\DanhSachXuatHang-" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss") + "-" + Guid.NewGuid().ToString() + ".xlsx";
            try
            {
                ExcelPackage pkg = new ExcelPackage(new System.IO.FileInfo(webHostEnvironment.WebRootPath + fileName));

                var ws = pkg.Workbook.Worksheets.Add(DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss"));
                int startRow = 2;
                int count = 1;
                var data = exportService.GetExportViewModels();

                ws.Cells[1, 1].Value = "STT";
                ws.Cells[1, 2].Value = "Mã xuất kho";
                ws.Cells[1, 3].Value = "Mã đơn hàng";
                ws.Cells[1, 4].Value = "Ngày đặt hàng";
                ws.Cells[1, 5].Value = "Ngày xuất hàng";
                ws.Cells[1, 6].Value = "Số loại sản phẩm";
                ws.Cells[1, 7].Value = "Tổng tiền";
                ws.Cells[1, 8].Value = "Địa chỉ";
                ws.Cells[1, 9].Value = "SDT";
                ws.Cells[1, 10].Value = "Họ tên";
                ws.Cells[1, 11].Value = "Email";
                ws.Cells[1, 12].Value = "Ghi chú";

                foreach (var item in data)
                {
                    ws.Cells[startRow, 1].Value = count++;
                    ws.Cells[startRow, 2].Value = item.ExportID;
                    ws.Cells[startRow, 3].Value = item.OrderCode;
                    ws.Cells[startRow, 4].Value = item.CreateDate?.ToString("hh:mm:ss, dd/MM/yyyy");
                    ws.Cells[startRow, 5].Value = item.ExportDate.ToString("hh:mm:ss, dd/MM/yyyy");
                    ws.Cells[startRow, 6].Value = item.ListProduct.Count;
                    ws.Cells[startRow, 7].Value = item.TotalPrice.GetValueOrDefault(0).ToString("N0");
                    ws.Cells[startRow, 8].Value = item.CustomerAddress;
                    ws.Cells[startRow, 9].Value = item.CustomerPhone;
                    ws.Cells[startRow, 10].Value = item.CustomerFullName;
                    ws.Cells[startRow, 11].Value = item.CustomerEmail;
                    ws.Cells[startRow, 12].Value = item.CustomerNote;
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
