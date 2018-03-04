using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkout.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}