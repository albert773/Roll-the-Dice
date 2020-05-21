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
    public class ElementoController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Elemento
        public IQueryable<Elemento> GetElemento()
        {
            return db.Elemento;
        }

        // GET: api/Elemento/5
        [ResponseType(typeof(Elemento))]
        public async Task<IHttpActionResult> GetElemento(int id)
        {
            Elemento elemento = await db.Elemento.FindAsync(id);
            if (elemento == null)
            {
                return NotFound();
            }

            return Ok(elemento);
        }

        // PUT: api/Elemento/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutElemento(int id, Elemento elemento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elemento.ID)
            {
                return BadRequest();
            }

            db.Entry(elemento).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementoExists(id))
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

        // POST: api/Elemento
        [ResponseType(typeof(Elemento))]
        public async Task<IHttpActionResult> PostElemento(Elemento elemento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Elemento.Add(elemento);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ElementoExists(elemento.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = elemento.ID }, elemento);
        }

        // DELETE: api/Elemento/5
        [ResponseType(typeof(Elemento))]
        public async Task<IHttpActionResult> DeleteElemento(int id)
        {
            Elemento elemento = await db.Elemento.FindAsync(id);
            if (elemento == null)
            {
                return NotFound();
            }

            db.Elemento.Remove(elemento);
            await db.SaveChangesAsync();

            return Ok(elemento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElementoExists(int id)
        {
            return db.Elemento.Count(e => e.ID == id) > 0;
        }
    }
}