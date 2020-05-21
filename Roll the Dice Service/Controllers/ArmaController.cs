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
    public class ArmaController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Arma
        public IQueryable<Arma> GetArma()
        {
            return db.Arma;
        }

        // GET: api/Arma/5
        [ResponseType(typeof(Arma))]
        public async Task<IHttpActionResult> GetArma(int id)
        {
            Arma arma = await db.Arma.FindAsync(id);
            if (arma == null)
            {
                return NotFound();
            }

            return Ok(arma);
        }

        // PUT: api/Arma/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArma(int id, Arma arma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != arma.ID)
            {
                return BadRequest();
            }

            db.Entry(arma).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmaExists(id))
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

        // POST: api/Arma
        [ResponseType(typeof(Arma))]
        public async Task<IHttpActionResult> PostArma(Arma arma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Arma.Add(arma);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArmaExists(arma.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = arma.ID }, arma);
        }

        // DELETE: api/Arma/5
        [ResponseType(typeof(Arma))]
        public async Task<IHttpActionResult> DeleteArma(int id)
        {
            Arma arma = await db.Arma.FindAsync(id);
            if (arma == null)
            {
                return NotFound();
            }

            db.Arma.Remove(arma);
            await db.SaveChangesAsync();

            return Ok(arma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArmaExists(int id)
        {
            return db.Arma.Count(e => e.ID == id) > 0;
        }
    }
}