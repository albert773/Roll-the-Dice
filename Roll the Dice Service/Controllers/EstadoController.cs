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
    public class EstadoController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Estado
        public IQueryable<Estado> GetEstado()
        {
            return db.Estado;
        }

        // GET: api/Estado/5
        [ResponseType(typeof(Estado))]
        public async Task<IHttpActionResult> GetEstado(int id)
        {
            Estado estado = await db.Estado.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            return Ok(estado);
        }

        // PUT: api/Estado/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstado(int id, Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estado.ID)
            {
                return BadRequest();
            }

            db.Entry(estado).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
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

        // POST: api/Estado
        [ResponseType(typeof(Estado))]
        public async Task<IHttpActionResult> PostEstado(Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estado.Add(estado);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstadoExists(estado.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = estado.ID }, estado);
        }

        // DELETE: api/Estado/5
        [ResponseType(typeof(Estado))]
        public async Task<IHttpActionResult> DeleteEstado(int id)
        {
            Estado estado = await db.Estado.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            db.Estado.Remove(estado);
            await db.SaveChangesAsync();

            return Ok(estado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadoExists(int id)
        {
            return db.Estado.Count(e => e.ID == id) > 0;
        }
    }
}