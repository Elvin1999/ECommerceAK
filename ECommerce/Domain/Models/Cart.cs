﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class Cart
    {
        public string CustomerName { get; set; }
        public List<CartLine> CartLines { get; set; }
    }
}
