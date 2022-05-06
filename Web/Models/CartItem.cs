using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    [Serializable]
    public class CartItem
    {
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
    }
}
