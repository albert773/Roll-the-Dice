using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Roll_the_Dice_Service.Models;

namespace Roll_the_Dice_Service.Controllers
{
    public class ItemController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Item
        public IQueryable<Item> GetItem()
        {
            return db.Item;
        }

        // GET: api/Item/5
        [ResponseType(typeof(Item))]
        public async Task<IHttpActionResult> GetItem(int id)
        {
            Item item = await db.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/Item/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.ID)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Item
        [ResponseType(typeof(Item))]
        public async Task<IHttpActionResult> PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Item.Add(item);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemExists(item.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = item.ID }, item);
        }

        // DELETE: api/Item/5
        [ResponseType(typeof(Item))]
        public async Task<IHttpActionResult> DeleteItem(int id)
        {
            Item item = await db.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            db.Item.Remove(item);
            await db.SaveChangesAsync();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Item.Count(e => e.ID == id) > 0;
        }
    }
}