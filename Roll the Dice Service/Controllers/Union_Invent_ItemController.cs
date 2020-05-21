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
    public class Union_Invent_ItemController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Union_Invent_Item
        public IQueryable<Union_Invent_Item> GetUnion_Invent_Item()
        {
            return db.Union_Invent_Item;
        }

        // GET: api/Union_Invent_Item/5
        [ResponseType(typeof(Union_Invent_Item))]
        public async Task<IHttpActionResult> GetUnion_Invent_Item(int id)
        {
            Union_Invent_Item union_Invent_Item = await db.Union_Invent_Item.FindAsync(id);
            if (union_Invent_Item == null)
            {
                return NotFound();
            }

            return Ok(union_Invent_Item);
        }

        // PUT: api/Union_Invent_Item/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnion_Invent_Item(int id, Union_Invent_Item union_Invent_Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != union_Invent_Item.ID_Item)
            {
                return BadRequest();
            }

            db.Entry(union_Invent_Item).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Union_Invent_ItemExists(id))
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

        // POST: api/Union_Invent_Item
        [ResponseType(typeof(Union_Invent_Item))]
        public async Task<IHttpActionResult> PostUnion_Invent_Item(Union_Invent_Item union_Invent_Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Union_Invent_Item.Add(union_Invent_Item);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Union_Invent_ItemExists(union_Invent_Item.ID_Item))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = union_Invent_Item.ID_Item }, union_Invent_Item);
        }

        // DELETE: api/Union_Invent_Item/5
        [ResponseType(typeof(Union_Invent_Item))]
        public async Task<IHttpActionResult> DeleteUnion_Invent_Item(int id)
        {
            Union_Invent_Item union_Invent_Item = await db.Union_Invent_Item.FindAsync(id);
            if (union_Invent_Item == null)
            {
                return NotFound();
            }

            db.Union_Invent_Item.Remove(union_Invent_Item);
            await db.SaveChangesAsync();

            return Ok(union_Invent_Item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Union_Invent_ItemExists(int id)
        {
            return db.Union_Invent_Item.Count(e => e.ID_Item == id) > 0;
        }
    }
}