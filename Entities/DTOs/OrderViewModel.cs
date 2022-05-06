using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string OrderCode { get; set; }

        public decimal? TotalPrice { get; set; }

        public int? OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        [StringLength(250)]
        public string CustomerAddress { get; set; }

        [StringLength(15)]
        public string CustomerPhone { get; set; }

        [StringLength(50)]
        public string CustomerFullName { get; set; }

        [StringLength(50)]
        public string CustomerEmail { get; set; }


        public DateTime? CreatedDate { get; set; }

        public List<OrderDetails> ListOrderDetails { get; set; }
    }
    public class OrderAdminViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string OrderCode { get; set; }

        public decimal? TotalPrice { get; set; }

        public int? OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        [StringLength(250)]
        public string CustomerAddress { get; set; }

        [StringLength(15)]
        public string CustomerPhone { get; set; }

        [StringLength(50)]
        public string CustomerFullName { get; set; }

        [StringLength(50)]
        public string CustomerEmail { get; set; }
        [StringLength(500)]
        public string CustomerNote { get; set; }


        public DateTime? CreatedDate { get; set; }

        public List<OrderDetailsViewModel> ListOrderDetails { get; set; }
    }
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? ProductPrice { get; set; }
    }

    public class TrackingOrderReceivedModel
    {
        [StringLength(50)]
        public string OrderCode { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? OrderStatusId { get; set; }
        [StringLength(250)]
        public string CustomerAddress { get; set; }
        [StringLength(15)]
        public string CustomerPhone { get; set; }
        [StringLength(50)]
        public string CustomerFullName { get; set; }
        [StringLength(50)]
        public string CustomerEmail { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<ProductOrder> ListProductOrder { get; set; }
    }

    public class OrderReceivedViewModel
    {
        [StringLength(50)]
        public string OrderCode { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? OrderStatusId { get; set; }
        [StringLength(50)]
        public string CustomerFullName { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
