using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utilities;

namespace Entities.DTOs
{
    public class CommonViewModel
    {
    }
    public class AccountDTO
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public int? Gender { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }
    }
    public class AccountRegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RePassword { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public int? Gender { get; set; }
        [Required]
        public DateTime? Birthday { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }
    }
    public class AccountLoginDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
    public class AccountChangePassDTO
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string oldpass { get; set; }
        public string newpassword { get; set; }
        public string renewpassword { get; set; }

    }
    public class ForgetDTO
    {
        public string Username { get; set; }
    }
    public class CategoryNewsViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public string CategoryDecription { get; set; }

        public int? CategoryOrder { get; set; }

        [StringLength(100)]
        public string MetaTitle { get; set; }

        [StringLength(100)]
        public string MetaDescription { get; set; }

        [StringLength(100)]
        public string MetaKeywords { get; set; }

        [StringLength(150)]
        public string Tags { get; set; }

        public bool IsHot { get; set; }

        public bool IsHome { get; set; }

        public bool IsView { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public int? NewsCount { get; set; }
    }
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        public int ParentId { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public string CategoryDecription { get; set; }

        public int? CategoryOrder { get; set; }

        [StringLength(100)]
        public string MetaTitle { get; set; }

        [StringLength(100)]
        public string MetaDescription { get; set; }

        [StringLength(100)]
        public string MetaKeywords { get; set; }

        [StringLength(150)]
        public string Tags { get; set; }

        public bool IsHot { get; set; }

        public bool IsHome { get; set; }

        public bool IsView { get; set; }
        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public int NewsCount { get; set; }
        public int ProductCount { get; set; }
        public List<Product> ListProducts { get; set; }
        public int CountProduct { get; set; }
    }
    public class RequestHomeViewModel : PagintionalBasic
    {
        public int? categoryId { get; set; }
    }
    public class RequestSearchModel : PagintionalBasic
    {
        public string KeyWord { get; set; }
        public string Order { get; set; }
    }
    public class ChangePasswordViewModel
    {
        public string username { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string reNewPassword { get; set; }
    }
    public class OrderRequestViewModel
    {
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerNote { get; set; }
        public List<ProductOrder> ProductsOrder { get; set; }
        public decimal? TotalPrice { get; set; }
    }
    public class OrderResponseViewModel
    {
        public string OrderCode { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerNote { get; set; }
        public List<ProductOrder> ProductsOrder { get; set; }
        public decimal? TotalPrice { get; set; }
    }
    public class DataAllTheoThang
    {
        public int DonHangMoi { get; set; }
        public int DonHangThanhCong { get; set; }
        public int DonHangThatBai { get; set; }
        public int DonHangHuy { get; set; }
        public decimal? DoanhThu { get; set; }
        public double TangTruong { get; set; }
    }
    public class DataBaoCaoNam
    {
        public DataAllTheoThang Thang1 { get; set; }
        public DataAllTheoThang Thang2 { get; set; }
        public DataAllTheoThang Thang3 { get; set; }
        public DataAllTheoThang Thang4 { get; set; }
        public DataAllTheoThang Thang5 { get; set; }
        public DataAllTheoThang Thang6 { get; set; }
        public DataAllTheoThang Thang7 { get; set; }
        public DataAllTheoThang Thang8 { get; set; }
        public DataAllTheoThang Thang9 { get; set; }
        public DataAllTheoThang Thang10 { get; set; }
        public DataAllTheoThang Thang11 { get; set; }
        public DataAllTheoThang Thang12 { get; set; }
    }
    public class DataBaoCao
    {
        public decimal? DoanhThu { get; set; }
        public decimal? DoanhThuPrev { get; set; }
        public int DonHangMoi { get; set; }
        public int DonHangThanhCong { get; set; }
        public int DonHangThatBai { get; set; }
        public int DonHangHuy { get; set; }
        public decimal? TangTruong { get; set; }
    }
    public class MenusViewModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public int OrderNum { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Icon { get; set; }
        public string Controller { get; set; }
        public string View { get; set; }
    }
    public class ProductCategoryShowOnHome
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }
        public int? CategoryOrder { get; set; }
        public List<ProductShowOnHomeModel> ListProducts { get; set; }
    }
    public class SendContactModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public int type { get; set; }
        public int objID { get; set; }
        public string url { get; set; }
    }
    public class ExportViewModel
    {
        public int ExportID { get; set; }
        public int OrderID { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime ExportDate { get; set; }
        [StringLength(50)]
        public string OrderCode { get; set; }
        public decimal? TotalPrice { get; set; }
        [StringLength(250)]
        public string CustomerAddress { get; set; }

        [StringLength(15)]
        public string CustomerPhone { get; set; }

        [StringLength(50)]
        public string CustomerFullName { get; set; }
        [StringLength(50)]
        public string CustomerEmail { get; set; }
        [StringLength(500)]
        public string CustomerNote { get; set; }
        public List<ProductOrder> ListProduct { get; set; }
    }
}
