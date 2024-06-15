using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        public int ID { get; set; }
        public int Rating { get;set; }
        public string Comment { get;set; }
    }
}
