namespace Entities.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Import")]
    public partial class Import
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Nane { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ImportedDate { get; set; }
        [StringLength(4000)]
        public string Note { get; set; }

    }
}
