using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class CartLine
    {
        public int Amount { get; set; }
        public Product Product{ get; set; }
    }
}
