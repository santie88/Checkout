using System.Collections.Generic;

namespace Framework.Models
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }

        public bool Closed { get; set; }
    }
}