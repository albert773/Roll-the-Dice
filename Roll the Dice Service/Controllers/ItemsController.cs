using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Roll_the_Dice_Service.Controllers
{
    [Authorize]
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        private IItemService ItemServ;

        public ItemsController(IItemService ItemServ)
        {
            this.ItemServ = ItemServ;
        }

        // GET: api/Items
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllItems()
        {
            IEnumerable<Item> items = ItemServ.GetAllItems();
            if (items.Count() > 0)
            {
                return Ok(items);
            }
            return BadRequest("No se ha encontrado ningun item");
        }

        // GET: api/Items/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Item))]
        public IHttpActionResult GetItem(int id)
        {
            Item item = ItemServ.GetItemById(id);
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

            try
            {
                ItemServ.PutItem(id, item);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
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

            ItemServ.PostItem(item);

            return Ok();
        }

        // DELETE: api/Items/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(int id)
        {
            ItemServ.DeleteItem(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}