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
    public class Union_Stat_PersController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Union_Stat_Pers
        public IQueryable<Union_Stat_Pers> GetUnion_Stat_Pers()
        {
            return db.Union_Stat_Pers;
        }

        // GET: api/Union_Stat_Pers/5
        [ResponseType(typeof(Union_Stat_Pers))]
        public async Task<IHttpActionResult> GetUnion_Stat_Pers(int id)
        {
            Union_Stat_Pers union_Stat_Pers = await db.Union_Stat_Pers.FindAsync(id);
            if (union_Stat_Pers == null)
            {
                return NotFound();
            }

            return Ok(union_Stat_Pers);
        }

        // PUT: api/Union_Stat_Pers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnion_Stat_Pers(int id, Union_Stat_Pers union_Stat_Pers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != union_Stat_Pers.ID_Personaje)
            {
                return BadRequest();
            }

            db.Entry(union_Stat_Pers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Union_Stat_PersExists(id))
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

        // POST: api/Union_Stat_Pers
        [ResponseType(typeof(Union_Stat_Pers))]
        public async Task<IHttpActionResult> PostUnion_Stat_Pers(Union_Stat_Pers union_Stat_Pers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Union_Stat_Pers.Add(union_Stat_Pers);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Union_Stat_PersExists(union_Stat_Pers.ID_Personaje))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = union_Stat_Pers.ID_Personaje }, union_Stat_Pers);
        }

        // DELETE: api/Union_Stat_Pers/5
        [ResponseType(typeof(Union_Stat_Pers))]
        public async Task<IHttpActionResult> DeleteUnion_Stat_Pers(int id)
        {
            Union_Stat_Pers union_Stat_Pers = await db.Union_Stat_Pers.FindAsync(id);
            if (union_Stat_Pers == null)
            {
                return NotFound();
            }

            db.Union_Stat_Pers.Remove(union_Stat_Pers);
            await db.SaveChangesAsync();

            return Ok(union_Stat_Pers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Union_Stat_PersExists(int id)
        {
            return db.Union_Stat_Pers.Count(e => e.ID_Personaje == id) > 0;
        }
    }
}