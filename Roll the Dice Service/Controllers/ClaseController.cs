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
    public class ClaseController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Clase
        public IQueryable<Clase> GetClase()
        {
            return db.Clase;
        }

        // GET: api/Clase/5
        [ResponseType(typeof(Clase))]
        public async Task<IHttpActionResult> GetClase(int id)
        {
            Clase clase = await db.Clase.FindAsync(id);
            if (clase == null)
            {
                return NotFound();
            }

            return Ok(clase);
        }

        // PUT: api/Clase/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClase(int id, Clase clase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clase.ID)
            {
                return BadRequest();
            }

            db.Entry(clase).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaseExists(id))
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

        // POST: api/Clase
        [ResponseType(typeof(Clase))]
        public async Task<IHttpActionResult> PostClase(Clase clase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clase.Add(clase);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClaseExists(clase.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = clase.ID }, clase);
        }

        // DELETE: api/Clase/5
        [ResponseType(typeof(Clase))]
        public async Task<IHttpActionResult> DeleteClase(int id)
        {
            Clase clase = await db.Clase.FindAsync(id);
            if (clase == null)
            {
                return NotFound();
            }

            db.Clase.Remove(clase);
            await db.SaveChangesAsync();

            return Ok(clase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClaseExists(int id)
        {
            return db.Clase.Count(e => e.ID == id) > 0;
        }
    }
}