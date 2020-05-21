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
    public class EstadisticaController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Estadistica
        public IQueryable<Estadistica> GetEstadistica()
        {
            return db.Estadistica;
        }

        // GET: api/Estadistica/5
        [ResponseType(typeof(Estadistica))]
        public async Task<IHttpActionResult> GetEstadistica(int id)
        {
            Estadistica estadistica = await db.Estadistica.FindAsync(id);
            if (estadistica == null)
            {
                return NotFound();
            }

            return Ok(estadistica);
        }

        // PUT: api/Estadistica/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstadistica(int id, Estadistica estadistica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadistica.ID)
            {
                return BadRequest();
            }

            db.Entry(estadistica).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadisticaExists(id))
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

        // POST: api/Estadistica
        [ResponseType(typeof(Estadistica))]
        public async Task<IHttpActionResult> PostEstadistica(Estadistica estadistica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estadistica.Add(estadistica);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstadisticaExists(estadistica.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = estadistica.ID }, estadistica);
        }

        // DELETE: api/Estadistica/5
        [ResponseType(typeof(Estadistica))]
        public async Task<IHttpActionResult> DeleteEstadistica(int id)
        {
            Estadistica estadistica = await db.Estadistica.FindAsync(id);
            if (estadistica == null)
            {
                return NotFound();
            }

            db.Estadistica.Remove(estadistica);
            await db.SaveChangesAsync();

            return Ok(estadistica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadisticaExists(int id)
        {
            return db.Estadistica.Count(e => e.ID == id) > 0;
        }
    }
}