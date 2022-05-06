using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OfficeOpenXml;
using Services.Common;
using Services.Import;
using Services.News;
using Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ultilities;

namespace Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProductController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICommonService _commonService;
        private readonly IProductService productService;
        private readonly IImportService importService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private IConfiguration iConfig;

        public ProductController(ICommonService commonService, IProductService productService, IWebHostEnvironment hostingEnvironment, IConfiguration iConfig, IWebHostEnvironment webHostEnvironment, IImportService _importService)
        {
            this._commonService = commonService;
            this.productService = productService;
            this.hostingEnvironment = hostingEnvironment;
            this.iConfig = iConfig;
            this._webHostEnvironment = webHostEnvironment;
            this.importService = _importService;
        }

        #region Private Function
        private void SetComboboxProductCategory()
        {
            ViewBag.ProductCategory = _commonService.GetListProductCategory().Select(p => new SelectListItem
            {
                Text = p.CategoryName,
                Value = p.Id.ToString()
            }).ToList();
        }
        #endregion

        /// <summary>
        /// API Upload ảnh
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UploadImages(int id)
        {
            try
            {
                var files = new List<IFormFile>();
                var listUpload = new List<ProductImages>();
                var fileExists = Request.Form.Files.Count > 0;
                foreach (IFormFile image in Request.Form.Files)
                {
                    if (image != null && FormFileExtensions.IsImage(image))
                    {
                        var objImage = new ProductImages();
                        string webRootPath = iConfig.GetSection("CustomSetting").GetSection("ImageWebRootPath").Value;
                        string physicalPath = hostingEnvironment.WebRootPath + iConfig.GetSection("CustomSetting").GetSection("ImageUploadPhysicalPath").Value;

                        string originalPath = FileService.Upload(image, physicalPath, webRootPath);
                        string scaledPath = FileService.ScaleImage(originalPath, image);
                        objImage.ProductId = id;
                        objImage.LargeImage = originalPath;
                        objImage.ThumbImage = scaledPath;

                        listUpload.Add(objImage);
                    }
                }
                var ins = productService.InsertOrUpdateProductImages(listUpload);
                return Json(new { success = "true" });
            }
            catch (Exception ex)
            {
                return Json(new { success = "false", error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = productService.GetProducts();
            return View(data);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            SetComboboxProductCategory();
            var data = productService.GetProduct(id);
            if (data == null)
            {
                SetAlert("error", "Không tìm thấy dữ liệu!");
                return RedirectToAction("Index", "Product");
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult MoreImages(int id)
        {
            try
            {
                if (id > 0 && productService.CheckExistProduct(id))
                {
                    ViewBag.CurrentId = id;
                    var listData = productService.GetAllProductImages(id);
                    return View(listData);
                }
                SetAlert("error", "Liên kết dữ liệu sản phẩm không chính xác!");
                return RedirectToAction("Index", "Product");
            }
            catch (Exception e)
            {
                SetAlert("error", e.Message);
                return RedirectToAction("Index", "Product");
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            SetComboboxProductCategory();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            SetComboboxProductCategory();
            try
            {
                if (model.ImageFile != null)
                {
                    var isImage = FormFileExtensions.IsImage(model.ImageFile);
                    if (isImage)
                    {
                        string webRootPath = iConfig.GetSection("CustomSetting").GetSection("ImageWebRootPath").Value;
                        string physicalPath = hostingEnvironment.WebRootPath + iConfig.GetSection("CustomSetting").GetSection("ImageUploadPhysicalPath").Value;

                        string originalPath = FileService.Upload(model.ImageFile, physicalPath, webRootPath);
                        string scaledPath = FileService.ScaleImage(originalPath, model.ImageFile);

                        model.MainImageLarge = originalPath;
                        model.MainImageThumb = scaledPath;
                    }
                    else
                    {
                        ModelState.AddModelError("FileUpload", "Tệp tải lên phải là hình ảnh!");
                    }
                }
                else
                {
                    model.MainImageLarge = "#";
                    model.MainImageThumb = "#";
                }
                var checkExistCode = productService.CheckExistProductCode(model.Code?.Trim());
                if (checkExistCode)
                {
                    ModelState.AddModelError("Code", "Đã tồn tại mã sản phẩm trong hệ thống!");
                }
                if (ModelState.IsValid)
                {
                    model.Remain = model.Quantity;
                    model.CreatedBy = this.HttpContext.Session.GetString("user");
                    model.CreatedDate = DateTime.Now;
                    var res = productService.InsertOrUpdateProduct(model);
                    if (res != null)
                    {
                        SetAlert("success", "Thêm mới dữ liệu thành công!");
                        return RedirectToAction("Create");
                    }
                    SetAlert("error", "Thêm mới dữ liệu thất bại!");
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
        public IActionResult Edit(int id)
        {
            SetComboboxProductCategory();
            var data = productService.GetProduct(id);
            if (data == null)
            {
                SetAlert("error", "Không tìm thấy dữ liệu!");
                return RedirectToAction("Index", "Product");
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            SetComboboxProductCategory();
            try
            {
                if (model.ImageFile != null)
                {
                    var isImage = FormFileExtensions.IsImage(model.ImageFile);
                    if (isImage)
                    {
                        string webRootPath = iConfig.GetSection("CustomSetting").GetSection("ImageWebRootPath").Value;
                        string physicalPath = hostingEnvironment.WebRootPath + iConfig.GetSection("CustomSetting").GetSection("ImageUploadPhysicalPath").Value;

                        string originalPath = FileService.Upload(model.ImageFile, physicalPath, webRootPath);
                        string scaledPath = FileService.ScaleImage(originalPath, model.ImageFile);

                        model.MainImageLarge = originalPath;
                        model.MainImageThumb = scaledPath;
                    }
                    else
                    {
                        ModelState.AddModelError("NewsImageUpload", "Tệp tải lên phải là hình ảnh!");
                        return View(model);
                    }
                }
                if (ModelState.IsValid)
                {
                    model.ModifiedBy = this.HttpContext.Session.GetString("user");
                    model.ModifiedDate = DateTime.Now;
                    var res = productService.InsertOrUpdateProduct(model);
                    if (res != null)
                    {
                        SetAlert("success", "Cập nhật dữ liệu thành công!");
                        return RedirectToAction("Index", "Product");
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

        public IActionResult Delete(int id)
        {
            try
            {
                var res = productService.DeleteProduct(id);
                if (res)
                {
                    SetAlert("success", "Xóa dữ liệu thành công!");
                    return RedirectToAction("Index", "Product");
                }
                return RedirectToAction("Index", "Product");
            }
            catch (Exception e)
            {
                SetAlert("error", "Có lỗi xảy ra:" + e.Message);
                return RedirectToAction("Index", "Product");
            }
        }

        public IActionResult ProductImagesDelete(int id, int productid)
        {
            try
            {
                var del = productService.ProductImagesDelete(id);
                if (del)
                {
                    SetAlert("success", "Xóa dữ liệu thành công!");
                }
                else
                {
                    SetAlert("error", "Xóa dữ liệu thất bại!");
                }
                return RedirectToAction("MoreImages", new { id = productid });
            }
            catch (Exception e)
            {
                SetAlert("error", "Có lỗi xảy ra: " + e.Message);
                return RedirectToAction("MoreImages", new { id = productid });
            }

        }

        public JsonResult SearchProductByKeyCode(string keyCode)
        {
            try
            {
                var result = productService.GetImportProductByKeyCode(keyCode);
                return Json(new { status = true, obj = result });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        //public JsonResult SearchProductById(float id)
        //{
        //    try
        //    {
        //        var sendId = (long)id;
        //        var result = productService.GetImportProductById(sendId);
        //        return Json(new { status = true, obj = result });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { status = false, message = ex.Message });
        //    }
        //}

        public JsonResult ExportExcel()
        {
            string fileName = @"\excel\ListAllProducts-" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss") + "-" + Guid.NewGuid().ToString() + ".xlsx";
            try
            {
                ExcelPackage pkg = new ExcelPackage(new System.IO.FileInfo(_webHostEnvironment.WebRootPath + fileName));

                var ws = pkg.Workbook.Worksheets.Add("ListAllProducts-" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss"));
                int startRow = 2;
                int count = 1;
                var data = productService.GetProducts().ToList();

                ws.Cells[1, 1].Value = "STT";
                ws.Cells[1, 2].Value = "Mã sản phẩm";
                ws.Cells[1, 3].Value = "Tên sản phẩm";
                ws.Cells[1, 4].Value = "Danh mục sản phẩm";
                ws.Cells[1, 5].Value = "Số lượng trong kho";
                ws.Cells[1, 6].Value = "Sản phẩm hot";
                ws.Cells[1, 7].Value = "Sản phẩm hiển thị trang chủ";
                ws.Cells[1, 8].Value = "Sản phẩm đang giảm giá";
                ws.Cells[1, 9].Value = "Giá gốc";
                ws.Cells[1, 10].Value = "Giá ưu đãi";

                foreach (var item in data)
                {
                    ws.Cells[startRow, 1].Value = count++;
                    ws.Cells[startRow, 2].Value = item.Code;
                    ws.Cells[startRow, 3].Value = item.Name;
                    ws.Cells[startRow, 4].Value = item.ProductCategory?.CategoryName;
                    ws.Cells[startRow, 5].Value = item.Quantity;
                    ws.Cells[startRow, 6].Value = item.IsHot ? "Có" : "Không";
                    ws.Cells[startRow, 7].Value = item.IsHome ? "Có" : "Không";
                    ws.Cells[startRow, 8].Value = item.IsPromote ? "Có" : "Không";
                    ws.Cells[startRow, 9].Value = item.Price.GetValueOrDefault(0).ToString("N0");
                    ws.Cells[startRow, 10].Value = item.PromotionPrice.GetValueOrDefault(0).ToString("N0");
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
