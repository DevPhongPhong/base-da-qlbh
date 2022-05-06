using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string OrderCode { get; set; }

        public decimal? TotalPrice { get; set; }
      
        // Type of status of order
        //  1: Danh sách đơn hàng chờ xác nhận
        //  2: Danh sách đơn hàng chờ giao hàng
        //  3: Danh sách đơn hàng đang được giao
        //  4: Danh sách đơn hàng đã được giao
        //  -1: Danh sách đơn hàng đã hủy
        //  -2: Danh sách đơn hàng giao thất bại
        public int? OrderStatusId { get; set; }

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
    }
}
