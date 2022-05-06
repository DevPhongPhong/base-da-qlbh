using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using Services.Import;
using Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ImportController : BaseController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IProductService productService;
        private readonly IImportService importService;

        public ImportController(IWebHostEnvironment _webHostEnvironment, IProductService _productService, IImportService _importService)
        {
            this.webHostEnvironment = _webHostEnvironment;
            this.productService = _productService;
            this.importService = _importService;
        }

        public IActionResult Index(int page = 1, int size = 10)
        {
            var model = importService.GetImportViewModels();
            ViewBag.CountRecord = model.Count();
            ViewBag.CurrentPage = page;
            ViewBag.CurrentSize = size;
            return View(model.Skip((page - 1) * size).Take(size));
        }

        [HttpGet]
        public IActionResult ImportProduct()
        {
            ViewBag.ListImportProduct = productService.GetAllImportProduct();
            return View();
        }

        [HttpPost]
        public IActionResult ImportProduct(string jsonString)
        {
            try
            {
                //Declare the variables used in Export Excel
                string fileName = @"\excel\Phiếu-nhập-hàng-" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss") + "-" + Guid.NewGuid().ToString() + ".xlsx";
                ExcelPackage pkg = new ExcelPackage(new System.IO.FileInfo(webHostEnvironment.WebRootPath + fileName));
                var ws = pkg.Workbook.Worksheets.Add("Phiếu-nhập-hàng-" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss"));
                int startRow = 7;
                int totalQuantity = 0;
                decimal totalPrice = 0;
                int countProducts = 0;
                //
                var ListProduct = JsonConvert.DeserializeObject<List<ImportProductViewModel>>(jsonString);

                ws.Cells["A1:G1"].Merge = true;
                ws.Cells["A2:G2"].Merge = true;
                ws.Cells["A3:G3"].Merge = true;
                ws.Cells["A4:G4"].Merge = true;
                ws.Cells["A5:G5"].Merge = true;
                ws.Cells["A1:G1"].Value = "Người Nhập: " + HttpContext.Session.GetString("user");
                ws.Cells["A2:G2"].Value = "Ngày Nhập:  " + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss");

                ws.Cells[6, 1].Value = "STT";
                ws.Cells[6, 2].Value = "Mã sản phẩm";
                ws.Cells[6, 3].Value = "ID trong cơ sở dữ liệu";
                ws.Cells[6, 4].Value = "Tên sản phẩm";
                ws.Cells[6, 5].Value = "Đơn giá";
                ws.Cells[6, 6].Value = "Số lượng nhập";
                ws.Cells[6, 7].Value = "Tổng";

                foreach (var item in ListProduct)
                {
                    if (productService.ImportProduct(item.ProductID, item.Quantity))
                    {
                        ws.Cells[startRow, 1].Value = startRow - 6;
                        ws.Cells[startRow, 2].Value = item.Code;
                        ws.Cells[startRow, 3].Value = item.ProductID;
                        ws.Cells[startRow, 4].Value = item.Name;
                        ws.Cells[startRow, 5].Value = item.Price.ToString("N0");
                        ws.Cells[startRow, 6].Value = item.Quantity;
                        ws.Cells[startRow, 7].Value = (item.Quantity * item.Price).ToString("N0");

                        countProducts++;
                        totalPrice += item.Quantity * item.Price;
                        totalQuantity += item.Quantity;
                        startRow++;
                    }
                }

                ws.Cells["A3:G3"].Value = "Số sản phẩm nhập: " + countProducts;
                ws.Cells["A4:G4"].Value = "Tổng số lượng sản phẩm nhập: " + totalQuantity;
                ws.Cells["A5:G5"].Value = "Tổng tiền nhập: " + totalPrice.ToString("N0");
                ws.Cells.AutoFitColumns();
                pkg.Save();

                var model = new ImportViewModel()
                {
                    Name = HttpContext.Session.GetString("user"),
                    CreatedDate = DateTime.Now,
                    ListImportProductViewModel = ListProduct,
                    Note = "",
                    TotalPrice = totalPrice
                };

                var res = importService.AddImport(model);

                return Json(new { status = (countProducts == ListProduct.Count() && res), filePath = fileName });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, mesage = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ImportDetail()
        {
            return View();
        }

        public JsonResult ExportExcel()
        {
            string fileName = @"\excel\DanhSachNhapHang-" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss") + "-" + Guid.NewGuid().ToString() + ".xlsx";
            try
            {
                ExcelPackage pkg = new ExcelPackage(new System.IO.FileInfo(webHostEnvironment.WebRootPath + fileName));

                var ws = pkg.Workbook.Worksheets.Add(DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss"));
                int startRow = 2;
                int count = 1;
                var data = importService.GetImportViewModels();

                ws.Cells[1, 1].Value = "STT";
                ws.Cells[1, 2].Value = "Mã đơn";
                ws.Cells[1, 3].Value = "Người đặt";
                ws.Cells[1, 4].Value = "Ngày đặt";
                ws.Cells[1, 5].Value = "Số loại sản phẩm";
                ws.Cells[1, 6].Value = "Tổng số lượng";
                ws.Cells[1, 7].Value = "Tổng tiền";
                ws.Cells[1, 8].Value = "Ghi chú";

                foreach (var item in data)
                {
                    ws.Cells[startRow, 1].Value = count++;
                    ws.Cells[startRow, 2].Value = item.ID;
                    ws.Cells[startRow, 3].Value = item.Name;
                    ws.Cells[startRow, 4].Value = item.CreatedDate.GetValueOrDefault().ToString("MM/dd/yyyy HH:mm:ss");
                    ws.Cells[startRow, 5].Value = item.CountProduct;
                    ws.Cells[startRow, 6].Value = item.TotalQuantity;
                    ws.Cells[startRow, 7].Value = item.TotalPrice.GetValueOrDefault(0).ToString("N0");
                    ws.Cells[startRow, 8].Value = item.Note;
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
