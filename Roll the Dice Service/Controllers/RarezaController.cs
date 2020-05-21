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
    public class RarezaController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Rareza
        public IQueryable<Rareza> GetRareza()
        {
            return db.Rareza;
        }

        // GET: api/Rareza/5
        [ResponseType(typeof(Rareza))]
        public async Task<IHttpActionResult> GetRareza(int id)
        {
            Rareza rareza = await db.Rareza.FindAsync(id);
            if (rareza == null)
            {
                return NotFound();
            }

            return Ok(rareza);
        }

        // PUT: api/Rareza/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRareza(int id, Rareza rareza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rareza.ID)
            {
                return BadRequest();
            }

            db.Entry(rareza).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RarezaExists(id))
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

        // POST: api/Rareza
        [ResponseType(typeof(Rareza))]
        public async Task<IHttpActionResult> PostRareza(Rareza rareza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rareza.Add(rareza);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RarezaExists(rareza.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rareza.ID }, rareza);
        }

        // DELETE: api/Rareza/5
        [ResponseType(typeof(Rareza))]
        public async Task<IHttpActionResult> DeleteRareza(int id)
        {
            Rareza rareza = await db.Rareza.FindAsync(id);
            if (rareza == null)
            {
                return NotFound();
            }

            db.Rareza.Remove(rareza);
            await db.SaveChangesAsync();

            return Ok(rareza);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RarezaExists(int id)
        {
            return db.Rareza.Count(e => e.ID == id) > 0;
        }
    }
}