using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("SubscribeEmail")]
    public class SubscribeEmail
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
