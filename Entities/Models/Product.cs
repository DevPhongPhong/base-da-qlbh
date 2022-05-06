namespace Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        public int? ProductImagesId { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        [StringLength(150)]
        public string MainImageThumb { get; set; }

        [StringLength(150)]
        public string MainImageLarge { get; set; }

        public bool IsHot { get; set; }

        public bool IsHome { get; set; }

        public bool IsPromote { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        public int Quantity { get; set; }
    }
}
