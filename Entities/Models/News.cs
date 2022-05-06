using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("News")]
    public partial class News
    {
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(500)]
        public string MetaUrl { get; set; }

        [StringLength(150)]
        public string ThumbImage { get; set; }

        [StringLength(150)]
        public string LargeImage { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(500)]
        public string SubTitle { get; set; }

        public string NewsContent { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        public DateTime? PostedDate { get; set; }

        public bool IsHot { get; set; }

        public bool IsHome { get; set; }

        public bool IsView { get; set; }

        public int? NewsOrder { get; set; }

        [StringLength(150)]
        public string Tags { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
