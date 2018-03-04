using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Checkout.Models;

namespace Checkout.Controllers
{
    public class ItemsController : ApiController
    {
        private ApplicationDbContext _context;

        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/items
        public IHttpActionResult GetItems()
        {
            var items = _context.Items.ToList();

            return Ok(items);
        }
    }
}
