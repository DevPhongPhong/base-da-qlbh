﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Entities.Models
{
    public class OrderAccount
    {
        public int OrderId { get; set; }
        public Guid AccountId { get; set; }
    }
}
