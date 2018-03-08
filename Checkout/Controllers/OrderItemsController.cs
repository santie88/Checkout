using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Checkout.DTOs;
using Checkout.Models;

namespace Checkout.Controllers
{
    public class OrderItemsController : ApiController
    {
        #region DBContext

        private ApplicationDbContext _context;

        public OrderItemsController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion

        #region Http

        // GET /api/OrderItems
        public IHttpActionResult GetOrderItems()
        {
            var orderItems = _context.OrderItems.Include(c => c.Item).Select(Mapper.Map<OrderItem, OrderItemDto>);

            return Ok(orderItems);
        }

        [HttpPost]
        public IHttpActionResult CreateOrderItem(OrderItemDto orderItemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var orderItem = Mapper.Map<OrderItemDto, OrderItem>(orderItemDto);
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();

            orderItemDto.Id = orderItem.Id;
            return Created(new Uri(Request.RequestUri + "/" + orderItem.Id), orderItemDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateOrderItem(int id, OrderItemDto orderItemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var orderItemInDb = _context.OrderItems.SingleOrDefault(c => c.Id == id);

            if (orderItemInDb == null)
                return NotFound();

            orderItemInDb.Quantity = orderItemDto.Quantity;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteOrderItem(int id)
        {
            var orderItemInDb = _context.OrderItems.SingleOrDefault(c => c.Id == id);

            if (orderItemInDb == null)
                return NotFound();

            _context.OrderItems.Remove(orderItemInDb);
            _context.SaveChanges();

            return Ok();
        }

        #endregion
    }
}
