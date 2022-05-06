using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        
        [Required]
        public int ParentId { get; set; }

        [StringLength(100)]
        public string CategoryName { get; set; }

        public string CategoryDecription { get; set; }

        public int? CategoryOrder { get; set; }

        public bool IsHot { get; set; }

        public bool IsHome { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
