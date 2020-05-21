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
    public class Union_Habil_PersController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Union_Habil_Pers
        public IQueryable<Union_Habil_Pers> GetUnion_Habil_Pers()
        {
            return db.Union_Habil_Pers;
        }

        // GET: api/Union_Habil_Pers/5
        [ResponseType(typeof(Union_Habil_Pers))]
        public async Task<IHttpActionResult> GetUnion_Habil_Pers(int id)
        {
            Union_Habil_Pers union_Habil_Pers = await db.Union_Habil_Pers.FindAsync(id);
            if (union_Habil_Pers == null)
            {
                return NotFound();
            }

            return Ok(union_Habil_Pers);
        }

        // PUT: api/Union_Habil_Pers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnion_Habil_Pers(int id, Union_Habil_Pers union_Habil_Pers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != union_Habil_Pers.ID_Personaje)
            {
                return BadRequest();
            }

            db.Entry(union_Habil_Pers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Union_Habil_PersExists(id))
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

        // POST: api/Union_Habil_Pers
        [ResponseType(typeof(Union_Habil_Pers))]
        public async Task<IHttpActionResult> PostUnion_Habil_Pers(Union_Habil_Pers union_Habil_Pers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Union_Habil_Pers.Add(union_Habil_Pers);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Union_Habil_PersExists(union_Habil_Pers.ID_Personaje))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = union_Habil_Pers.ID_Personaje }, union_Habil_Pers);
        }

        // DELETE: api/Union_Habil_Pers/5
        [ResponseType(typeof(Union_Habil_Pers))]
        public async Task<IHttpActionResult> DeleteUnion_Habil_Pers(int id)
        {
            Union_Habil_Pers union_Habil_Pers = await db.Union_Habil_Pers.FindAsync(id);
            if (union_Habil_Pers == null)
            {
                return NotFound();
            }

            db.Union_Habil_Pers.Remove(union_Habil_Pers);
            await db.SaveChangesAsync();

            return Ok(union_Habil_Pers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Union_Habil_PersExists(int id)
        {
            return db.Union_Habil_Pers.Count(e => e.ID_Personaje == id) > 0;
        }
    }
}