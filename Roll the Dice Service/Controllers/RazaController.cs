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
    public class RazaController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Raza
        public IQueryable<Raza> GetRaza()
        {
            return db.Raza;
        }

        // GET: api/Raza/5
        [ResponseType(typeof(Raza))]
        public async Task<IHttpActionResult> GetRaza(int id)
        {
            Raza raza = await db.Raza.FindAsync(id);
            if (raza == null)
            {
                return NotFound();
            }

            return Ok(raza);
        }

        // PUT: api/Raza/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRaza(int id, Raza raza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != raza.ID)
            {
                return BadRequest();
            }

            db.Entry(raza).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RazaExists(id))
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

        // POST: api/Raza
        [ResponseType(typeof(Raza))]
        public async Task<IHttpActionResult> PostRaza(Raza raza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Raza.Add(raza);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RazaExists(raza.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = raza.ID }, raza);
        }

        // DELETE: api/Raza/5
        [ResponseType(typeof(Raza))]
        public async Task<IHttpActionResult> DeleteRaza(int id)
        {
            Raza raza = await db.Raza.FindAsync(id);
            if (raza == null)
            {
                return NotFound();
            }

            db.Raza.Remove(raza);
            await db.SaveChangesAsync();

            return Ok(raza);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RazaExists(int id)
        {
            return db.Raza.Count(e => e.ID == id) > 0;
        }
    }
}