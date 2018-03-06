﻿using System.ComponentModel.DataAnnotations;

namespace Checkout.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public Order Order { get; set; }

        [Required]
        public int OrderId { get; set; }

        public Item Item { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}