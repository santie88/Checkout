using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Checkout.Models
{
    public class Order
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public bool Closed { get; set; }
    }
}