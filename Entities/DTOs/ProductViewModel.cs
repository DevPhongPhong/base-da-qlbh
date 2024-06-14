using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DTOs
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public int? CategoryId { get; set; }

        public int? ProductImagesId { get; set; }

        public int? Tags { get; set; }
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }
        public string SubDes { get; set; }
        public string Branch { get; set; }
        [Required]
        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public bool hasVAT { get; set; }

        public int? Quantity { get; set; }

        public int? Remain { get; set; }

        public IFormFile ImageFile { get; set; }

        [StringLength(150)]
        public string MainImageThumb { get; set; }

        [StringLength(150)]
        public string MainImageLarge { get; set; }

        [StringLength(150)]
        public string Warranty { get; set; }

        public int? LikeCount { get; set; }

        public int? CommentCount { get; set; }

        public int? ViewCount { get; set; }

        public int? ReviewLevel { get; set; }

        public bool IsHot { get; set; }

        public bool IsHome { get; set; }

        public bool IsView { get; set; }

        public bool IsPromote { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiredPromote { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiredHot { get; set; }
        public int? Status { get; set; }

        [StringLength(100)]
        public string MetaTitle { get; set; }

        [StringLength(100)]
        public string MetaKeywords { get; set; }

        [StringLength(200)]
        public string MetaDescriptions { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        public int? currentCategoryId { get; set; }
        public List<Feedback> Feedbacks { get;set; }
        public ProductCategory ProductCategory { get; set; }
        public List<ProductImages> ProductImages { get; set; }
    }
    public class ProductItemViewModel
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? ProductImagesId { get; set; }

        public int? ProductGroupId { get; set; }

        [StringLength(150)]
        public string ProductGroupName { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(250)]
        public string ImageThumb { get; set; }

        [StringLength(250)]
        public string ImageLarge { get; set; }

        public int? Quantity { get; set; }

        public int? Remain { get; set; }

        public decimal? DifferentPrice { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        public IFormFile ImageFile { get; set; }
        public Product Product { get; set; }
    }
    public class ProductGroupViewModel
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public decimal? ProductPrice { get; set; }
    }
    public class ProductShowOnHomeModel
    {
        public int Id { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        [StringLength(150)]
        public string MainImageThumb { get; set; }
        public bool IsPromote { get; set; }
    }
    public class ImportProductViewModel
    {
        public int ImportID { get; set; }
        public int ProductID { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
    public class ImportViewModel
    {
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Note { get; set; }
        public int CountProduct { get; set; }
        public int TotalQuantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public List<ImportProductViewModel> ListImportProductViewModel{ get; set; }
    }
}
