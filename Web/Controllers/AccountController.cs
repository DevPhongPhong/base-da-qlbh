﻿using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Common;
using Services.News;
using System;
using System.Linq;
using Services.Kaafly;
using Services.Product;
using Ultilities;
using System.Text.RegularExpressions;

namespace Web.Controllers
{
    public class AccountController : WebBaseController
    {
        private ICommonService commonService;
        private IKaaflyService kaaflyService;
        private IProductService productService;
        private INewsService newsService;
        public AccountController(ICommonService _commonService, IKaaflyService _kaaflyService, IProductService _productService, INewsService _newsService)
        {
            this.kaaflyService = _kaaflyService;
            this.productService = _productService;
            this.newsService = _newsService;
            this.commonService = _commonService;
        }
        [Route("tai-khoan")]
        [HttpGet]
        public IActionResult Index()
        {
            var member = GetMemberData();
            if (member != null)
            {
                GetDataMenu();
                return View(member);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [Route("tai-khoan")]
        [HttpPost]
        public IActionResult Index(Accounts account)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewData["Error"] = "Cần nhập đầy đủ các trường dữ liệu bắt buộc!";
                    return View(account);
                }
                if (account.Birthday.Value.Year < 1899 || account.Birthday > DateTime.Now)
                {
                    ViewData["Error"] = "Ngày sinh không phù hợp!";
                    return View(account);
                }
                account.ModifiedBy = GetMemberData().Username;
                account.ModifiedDate = DateTime.Now;
                var check = commonService.InsertOrUpdateAccount(account);
                if (check)
                {
                    ViewData["Success"] = "Cập nhật thông tin tài khoản thành công!";
                    SetMemberData(account);
                    return View(account);
                }
                else
                {
                    ViewData["Error"] = "Có lỗi trong quá trình cập nhật tài khoản!";
                    return View(account);
                }
            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Có lỗi trong quá trình cập nhật tài khoản!";
                return View(account); ;
            }

        }

        [Route("doi-mat-khau")]
        [HttpGet]
        public IActionResult ChangePass()
        {
            var member = GetMemberData();
            if (member != null)
            {
                GetDataMenu();
                var data = new AccountChangePassDTO();
                data.id = member.Id;
                data.username = member.Username;
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [Route("doi-mat-khau")]
        [HttpPost]
        public IActionResult ChangePass(AccountChangePassDTO account)
        {
            account.oldpass = EncryptExtensions.Hash(account.oldpass, null);
            account.newpassword = EncryptExtensions.Hash(account.newpassword, null);
            account.renewpassword = EncryptExtensions.Hash(account.renewpassword, null);

            if (account.oldpass != GetMemberData().Password)
            {
                ViewData["Error"] = "Mật khẩu cũ không đúng!";
                GetDataMenu();
                return View(account);
            }
            if (account.oldpass == account.newpassword)
            {
                ViewData["Error"] = "Mật khẩu cũ không được giống mật khẩu mới!";
                GetDataMenu();
                return View(account);
            }
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Cần nhập đầy đủ các trường dữ liệu bắt buộc!";
                GetDataMenu();
                return View(account);
            }
            if (account.newpassword != account.renewpassword)
            {
                ViewData["Error"] = "2 mật khẩu mới không trùng nhau!";
                GetDataMenu();
                return View(account);
            }

            var member = GetMemberData();
            member.ModifiedBy = member.Username;
            member.ModifiedDate = DateTime.Now;
            member.Password = account.newpassword;
            var check = commonService.InsertOrUpdateAccount(member);
            if (check)
            {
                ViewData["Success"] = "Cập nhật thông tin tài khoản thành công!";
                SetMemberData(member);
                GetDataMenu();
                return View(account);
            }
            else
            {
                ViewData["Error"] = "Có lỗi trong quá trình cập nhật tài khoản!";
                GetDataMenu();
                return View(account);
            }
        }

        [Route("quen-mat-khau")]
        [HttpGet]
        public IActionResult Forget()
        {
            GetDataMenu();
            var member = GetMemberData();
            if (member == null)
            {
                return View(member);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [Route("quen-mat-khau")]
        [HttpPost]
        public IActionResult Forget(ForgetDTO forget)
        {
            var member = GetMemberData();
            if (member == null)
            {
                GetDataMenu();
                return View(member);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        [Route("dang-nhap")]
        public IActionResult Login()
        {
            var member = GetMemberData();
            if (member == null)
            {
                GetDataMenu();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private bool ValidatePasswordComplexity(string password)
        {
            const int minLength = 8;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{" + minLength + ",}$";
            Regex regex = new(pattern);
            return regex.IsMatch(password);
        }

        [HttpPost]
        [Route("dang-nhap")]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AccountLoginDTO member)
        {
            try
            {
                if (!ValidatePasswordComplexity(member.password))
                {
                    ViewData["Error"] = "Mật khẩu phải có ít nhất 8 ký tự, chứa chữ cái thường, chữ hoa, số và ký tự đặc biệt!";
                    GetDataMenu();
                    return View(member);
                }

                member.password = EncryptExtensions.Hash(member.password, null);

                var check = commonService.AccountLogin(member);
                if (check != null)
                {
                    SetMemberData(check);
                    ViewBag.ListHomeHot = kaaflyService.GetListProductByHomeHot(true, true, 10);
                    ViewBag.ListHome = kaaflyService.GetListProductByHomeHot(true, false, 10);
                    ViewBag.NewsHomeHot = newsService.GetRandomHotNewses(3);
                    ViewBag.HotCategoryProduct = productService.GetListProductCategoryByHomeHot(true, true, 10);
                    ViewBag.ProductCategoryShowOnHome = productService.GetAllProductCategoryShowOnHome(true, true, 5);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Error"] = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                    GetDataMenu();
                    return View(member);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet]
        [Route("dang-xuat")]
        public IActionResult Logout()
        {
            ClearMemberData();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Route("dang-ky")]
        public IActionResult Register()
        {
            var member = GetMemberData();
            if (member == null)
            {
                GetDataMenu();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [Route("dang-ky")]
        [ValidateAntiForgeryToken]
        public IActionResult Register(AccountRegisterDTO register)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Cần nhập đầy đủ các trường dữ liệu bắt buộc!";
                GetDataMenu();
                return View(register);
            }
            if (register.Birthday.Value.Year < 1899 || register.Birthday > DateTime.Now)
            {
                ViewData["Error"] = "Ngày sinh không phù hợp!";
                GetDataMenu();
                return View(register);
            }
            if (register.Password != register.RePassword)
            {
                ViewData["Error"] = "2 mật khẩu không trùng nhau!";
                GetDataMenu();
                return View(register);
            }
            if (commonService.CheckExistAccountUserName(register.Username))
            {
                ViewData["Error"] = "Tên tài khoản tồn tại!";
                GetDataMenu();
                return View(register);
            }
            if (commonService.CheckExistAccountEmail(register.Email))
            {
                ViewData["Error"] = "Email đã đăng ký!";
                GetDataMenu();
                return View(register);
            }
            if (commonService.CheckExistAccountPhoneNumber(register.Phone))
            {
                ViewData["Error"] = "Số điện thoại đã đăng ký!";
                GetDataMenu();
                return View(register);
            }

            var newAccount = new Accounts();
            newAccount.Username = register.Username;
            newAccount.Password = EncryptExtensions.Hash(register.Password, null);
            newAccount.Phone = register.Phone;
            newAccount.Email = register.Email;
            newAccount.CreateBy = register.Username;
            newAccount.CreateDate = DateTime.Now;
            newAccount.IsActive = true;
            newAccount.Birthday = register.Birthday;
            newAccount.Address = register.Address;
            newAccount.FullName = register.FullName;
            newAccount.Gender = register.Gender;
            var check = commonService.InsertOrUpdateAccount(newAccount);
            
            if (check)
            {
                var account = commonService.AccountLogin(new AccountLoginDTO { username = newAccount.Username, password = newAccount.Password });
                SetMemberData(account);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Error"] = "Có lỗi trong quá trình đăng ký!";
                GetDataMenu();
                return View(register);
            }
        }

        #region private Func
        private Accounts GetMemberData()
        {
            var member = HttpContext.Session.GetString("member");
            var data = member != null ? JsonConvert.DeserializeObject<Accounts>(member) : null;
            return data;
        }
        private void SetMemberData(Accounts member)
        {
            string jsonData = JsonConvert.SerializeObject(member);
            HttpContext.Session.SetString("member", jsonData);
        }
        private void ClearMemberData()
        {
            var session = HttpContext.Session;
            session.Remove("member");
        }
        private void GetDataMenu()
        {
            TempData["productmenu"] = commonService.GetListProductCategory().OrderBy(x => x.CategoryOrder).ToList();
            TempData["newsmenu"] = commonService.GetListCategoryNews().OrderBy(x => x.CategoryOrder).ToList();
        }
        #endregion
    }
}
