using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Export")]
    public class Export
    {
        [Key]
        public int ID { get; set; }
        public int OrderID { get; set; }
        public DateTime ExportedDate { get; set; }

    }
}
