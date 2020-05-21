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
    public class AccionController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Accion
        public IQueryable<Accion> GetAccion()
        {
            return db.Accion;
        }

        // GET: api/Accion/5
        [ResponseType(typeof(Accion))]
        public async Task<IHttpActionResult> GetAccion(int id)
        {
            Accion accion = await db.Accion.FindAsync(id);
            if (accion == null)
            {
                return NotFound();
            }

            return Ok(accion);
        }

        // PUT: api/Accion/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAccion(int id, Accion accion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accion.ID)
            {
                return BadRequest();
            }

            db.Entry(accion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccionExists(id))
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

        // POST: api/Accion
        [ResponseType(typeof(Accion))]
        public async Task<IHttpActionResult> PostAccion(Accion accion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accion.Add(accion);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AccionExists(accion.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accion.ID }, accion);
        }

        // DELETE: api/Accion/5
        [ResponseType(typeof(Accion))]
        public async Task<IHttpActionResult> DeleteAccion(int id)
        {
            Accion accion = await db.Accion.FindAsync(id);
            if (accion == null)
            {
                return NotFound();
            }

            db.Accion.Remove(accion);
            await db.SaveChangesAsync();

            return Ok(accion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccionExists(int id)
        {
            return db.Accion.Count(e => e.ID == id) > 0;
        }
    }
}