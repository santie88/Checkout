using System.ComponentModel.DataAnnotations;
using Checkout.Models;

namespace Checkout.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}