using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("dbroot.Roles")]
    public class Roles
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
