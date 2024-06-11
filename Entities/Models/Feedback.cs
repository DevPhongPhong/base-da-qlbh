using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(12)]
        public string PhoneNumber { get; set; }
        [StringLength(500)]
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Avatar { get; set; }
        /// <summary>
        /// Type of Feed back
        /// </summary>
        /// <value>
        /// 1: Meassage
        /// 2: Comment Product
        /// 3: Comment News
        /// </value>
        public int Type { get; set; }
        public DateTime CreateDate { get; set; }
        public int ProductID { get; set; }
        public int NewsID { get; set; }
        public bool Status { get; set; }
        public bool ShowOnHome { get; set; }
    }
}
