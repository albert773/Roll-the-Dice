using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Roll_the_Dice_Service.Controllers
{
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Item> ItemDTO = uw.RepositoryClient<Item>();

        // GET: api/Items
        [HttpGet]
        [Route("")]
        public IEnumerable<Item> GetAllItems()
        {
            IEnumerable<Item> items = ItemDTO.GetAll();
            if (items.Count() > 0)
            {
                return items.ToList();
            }
            return items;
        }

        // GET: api/Items/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Item))]
        public IHttpActionResult GetItem(int id)
        {
            Item item = ItemDTO.GetByID(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/Items/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.itemId)
            {
                return BadRequest();
            }

            ItemDTO.Update(item);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("El item se ha modificado correctamente");
        }

        // POST: api/Items
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Item))]
        public IHttpActionResult PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ItemDTO.Insert(item);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Items/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(int id)
        {
            Item item = ItemDTO.GetByID(id);
            if (item == null)
            {
                return NotFound();
            }

            ItemDTO.Delete(item);
            uw.SaveChanges();

            return Ok("Se ha eliminado correctamente");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uw.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return ItemDTO.getDbSet().Count(e => e.itemId == id) > 0;
        }
    }
}