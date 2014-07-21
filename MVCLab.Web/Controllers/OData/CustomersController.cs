using MVCLab.Domain.CRM;
using MVCLab.Infrastructure.Data.CRM;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace MVCLab.Web.Controllers.OData
{
    public class CustomersController : ODataController
    {
        MVCLabContext db = new MVCLabContext();
        [EnableQuery]
        public IQueryable<Customer> Get()
        {
            return db.Customers;
        }
        [EnableQuery]
        public SingleResult<Customer> Get([FromODataUri] int key)
        {
            IQueryable<Customer> result = db.Customers.Where(p => p.ID== key);
            return SingleResult.Create(result);
        }

        /// <summary>
        /// ADD
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Post(Customer product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Customers.Add(product);
            await db.SaveChangesAsync();
            return Created(product);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="key"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Customer> product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Customers.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            product.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Customer update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.ID)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var product = await db.Customers.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            db.Customers.Remove(product);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool ProductExists(int key)
        {
            return db.Customers.Any(p => p.ID == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
