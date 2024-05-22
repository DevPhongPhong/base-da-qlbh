using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("staticdatas")]
    public class StaticData
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string Key { get; set; }
        [Required]
        [StringLength(255)]
        public string Value { get; set; }
    }
}
