using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Checkout.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }

        public bool Closed { get; set; }
    }
}