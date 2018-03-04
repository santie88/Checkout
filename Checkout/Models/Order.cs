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
        [Required]
        [StringLength(10)]
        public string Number { get; set; }
        [Required]
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public bool Closed { get; set; }
    }
}