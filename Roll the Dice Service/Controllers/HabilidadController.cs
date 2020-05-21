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
    public class HabilidadController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Habilidad
        public IQueryable<Habilidad> GetHabilidad()
        {
            return db.Habilidad;
        }

        // GET: api/Habilidad/5
        [ResponseType(typeof(Habilidad))]
        public async Task<IHttpActionResult> GetHabilidad(int id)
        {
            Habilidad habilidad = await db.Habilidad.FindAsync(id);
            if (habilidad == null)
            {
                return NotFound();
            }

            return Ok(habilidad);
        }

        // PUT: api/Habilidad/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHabilidad(int id, Habilidad habilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != habilidad.ID)
            {
                return BadRequest();
            }

            db.Entry(habilidad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabilidadExists(id))
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

        // POST: api/Habilidad
        [ResponseType(typeof(Habilidad))]
        public async Task<IHttpActionResult> PostHabilidad(Habilidad habilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Habilidad.Add(habilidad);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HabilidadExists(habilidad.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = habilidad.ID }, habilidad);
        }

        // DELETE: api/Habilidad/5
        [ResponseType(typeof(Habilidad))]
        public async Task<IHttpActionResult> DeleteHabilidad(int id)
        {
            Habilidad habilidad = await db.Habilidad.FindAsync(id);
            if (habilidad == null)
            {
                return NotFound();
            }

            db.Habilidad.Remove(habilidad);
            await db.SaveChangesAsync();

            return Ok(habilidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HabilidadExists(int id)
        {
            return db.Habilidad.Count(e => e.ID == id) > 0;
        }
    }
}