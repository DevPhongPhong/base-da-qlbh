using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("dbroot.CategoryNews")]
    public partial class CategoryNews
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
    }
}
