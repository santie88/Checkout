using System.Linq;
using System.Web.Http;
using Checkout.Models;

namespace Checkout.Controllers
{
    public class ItemsController : ApiController
    {
        #region DBContext

        private ApplicationDbContext _context;

        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion

        #region Actions

        // GET /api/items
        public IHttpActionResult GetItems()
        {
            var items = _context.Items.ToList();

            return Ok(items);
        }

        #endregion
    }
}
