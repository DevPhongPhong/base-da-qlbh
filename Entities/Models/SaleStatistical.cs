using System;

namespace Entities.Models
{
    public class ProductStatistical
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
