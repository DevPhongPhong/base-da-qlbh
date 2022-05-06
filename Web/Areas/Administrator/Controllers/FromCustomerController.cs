using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.FromCustomer;
using OfficeOpenXml;
using Microsoft.AspNetCore.Hosting;

namespace Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class FromCustomerController : BaseController
    {
        private readonly IFromCustomerService fcService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public FromCustomerController(IFromCustomerService _fcService, IWebHostEnvironment _webHostEnvironment)
        {
            this.fcService = _fcService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [HttpGet]
        public IActionResult FeedbackFromCustomer(int type = 0)
        {
            try
            {
                ViewBag.Type = type;


                if (type == 0)
                {
                    var model = fcService.GetFeedbacks();
                    ViewData["Title"] = "Tất cả Feedback";
                    return View(model);
                }
                if (type == 1)
                {
                    var model = fcService.GetMessages();
                    ViewData["Title"] = "Lời nhắn";
                    return View(model);
                }
                if (type == 2)
                {
                    var model = fcService.GetProductComments();
                    ViewData["Title"] = "Comment sản phẩm";
                    return View(model);
                }
                if (type == 3)
                {
                    var model = fcService.GetNewsComments();
                    ViewData["Title"] = "Comment tin tức";
                    return View(model);
                }
                TempData["Error"] = "Có lỗi xảy ra!";
                return RedirectToAction("Index", "Default");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Có lỗi xảy ra!";
                return RedirectToAction("Index", "Default");
            }

        }
        [HttpGet]
        public IActionResult EmailSubscribe()
        {
            try
            {
                ViewData["Title"] = "Comment sản phẩm";
                var model = fcService.GetSubscribeEmails();
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Có lỗi xảy ra!";
                return RedirectToAction("Index", "Default");
            }
        }
        [HttpPost]
        public IActionResult ChangeFeedbackStatus(int ID)
        {
            try
            {
                return Json(new { id = ID, status = fcService.ChangeStatusFeedback(ID) });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult ChangeFeedbackShowOnHome(int ID)
        {
            try
            {
                return Json(new { id = ID, status = fcService.ChangeShowOnHomeFeedback(ID)});
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult DeleteFeedBack(int ID)
        {
            try
            {
                var check = fcService.DeleteFeedBack(ID);
                if (check)
                {
                    SetAlert("success", "Xóa dữ liệu thành công!");
                    return Json(new { id = ID, status = check });
                }
                else
                {
                    SetAlert("error", "Có lỗi xảy ra");
                    return Json(new { id = ID, status = check });
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult DeleteSubscribeEmal(int ID)
        {
            try
            {
                var check = fcService.DeleteSubscribeEmail(ID);
                if (check)
                {
                    SetAlert("success", "Xóa dữ liệu thành công!");
                    return Json(new { id = ID, status = check });
                }
                else
                {
                    SetAlert("error", "Có lỗi xảy ra");
                    return Json(new { id = ID, status = check });
                }
            }
            catch (Exception ex)
            {
                SetAlert("error", "Có lỗi xảy ra:" + ex.Message);
                return Json(new { status = false, message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult EmailSubscribeExportExcel()
        {
            try
            {
                string fileName = @"\excel\DanhSachEmailDangKy-" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss") + "-" + Guid.NewGuid().ToString() + ".xlsx";
                ExcelPackage pkg = new ExcelPackage(new System.IO.FileInfo(webHostEnvironment.WebRootPath + fileName));

                var ws = pkg.Workbook.Worksheets.Add("DanhSachFeedback-" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss"));
                int startRow = 2;
                int count = 1;
                var data = fcService.GetSubscribeEmails().ToList();

                ws.Cells[1, 1].Value = "STT";
                ws.Cells[1, 2].Value = "Email";
                ws.Cells[1, 3].Value = "Ngày Đăng ký";

                foreach (var item in data)
                {
                    ws.Cells[startRow, 1].Value = count++;
                    ws.Cells[startRow, 2].Value = item.Email;
                    ws.Cells[startRow, 3].Value = item.CreateDate.ToString("MM/dd/yyyy HH:mm:ss");
                    startRow++;
                }
                ws.Cells.AutoFitColumns();
                pkg.Save();
                return Json(new { status = true, filePath = fileName });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }

    }
}
