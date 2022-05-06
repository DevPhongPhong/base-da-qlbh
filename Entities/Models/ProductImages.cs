using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("ProductImages")]
    public class ProductImages
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }
        public int? ProductItemId { get; set; }

        [StringLength(500)]
        public string LargeImage { get; set; }
        [StringLength(500)]
        public string ThumbImage { get; set; }
    }
}
