﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Checkout.DTOs;
using Checkout.Models;

namespace Checkout.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Orders
        public IHttpActionResult GetOrders()
        {
            var orders = _context.Orders.Include(c => c.Customer).Select(Mapper.Map<Order, OrderDto>);
            _context.OrderItems.Include(c => c.Item).Select(Mapper.Map<OrderItem, OrderItemDto>).ToList();

            return Ok(orders);
        }

        // GET /api/Orders/Id
        public IHttpActionResult GetOrders(int id)
        {
            var orders = _context.Orders.Include(c => c.Customer).Select(Mapper.Map<Order, OrderDto>);
            _context.OrderItems.Include(c => c.Item).Select(Mapper.Map<OrderItem, OrderItemDto>).ToList();

            return Ok(orders);
        }

        [HttpPost]
        public IHttpActionResult CreateOrder(OrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var order = Mapper.Map<OrderDto, Order>(orderDto);

            if (order.Id == 0)
            {
                _context.Orders.Add(order);
            }
            else
            {
                var orderInDb = _context.Orders.Single(m => m.Id == order.Id);

                orderInDb.Closed = order.Closed;
            }

            _context.SaveChanges();

            orderDto.Id = order.Id;
            return Created(new Uri(Request.RequestUri + "/" + order.Id), orderDto);
        }
        
        [HttpPut]
        public IHttpActionResult UpdateOrder(int id, OrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var orderInDb = _context.Orders.SingleOrDefault(c => c.Id == id);

            if (orderInDb == null)
                return NotFound();

            orderInDb.Closed = orderDto.Closed;

            _context.SaveChanges();

            return Ok();
        }
    }
}
