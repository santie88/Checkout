using System.Linq;
using System.Web.Http;
using Checkout.Models;

namespace Checkout.Controllers
{
    public class CustomersController : ApiController
    {
        #region DBContext

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion

        #region Actions

        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();

            return Ok(customers);
        }

        #endregion
    }
}
