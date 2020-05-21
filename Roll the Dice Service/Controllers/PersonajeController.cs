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
    public class PersonajeController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Personaje
        public IQueryable<Personaje> GetPersonaje()
        {
            return db.Personaje;
        }

        // GET: api/Personaje/5
        [ResponseType(typeof(Personaje))]
        public async Task<IHttpActionResult> GetPersonaje(int id)
        {
            Personaje personaje = await db.Personaje.FindAsync(id);
            if (personaje == null)
            {
                return NotFound();
            }

            return Ok(personaje);
        }

        // PUT: api/Personaje/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersonaje(int id, Personaje personaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personaje.ID)
            {
                return BadRequest();
            }

            db.Entry(personaje).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonajeExists(id))
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

        // POST: api/Personaje
        [ResponseType(typeof(Personaje))]
        public async Task<IHttpActionResult> PostPersonaje(Personaje personaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personaje.Add(personaje);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonajeExists(personaje.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = personaje.ID }, personaje);
        }

        // DELETE: api/Personaje/5
        [ResponseType(typeof(Personaje))]
        public async Task<IHttpActionResult> DeletePersonaje(int id)
        {
            Personaje personaje = await db.Personaje.FindAsync(id);
            if (personaje == null)
            {
                return NotFound();
            }

            db.Personaje.Remove(personaje);
            await db.SaveChangesAsync();

            return Ok(personaje);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonajeExists(int id)
        {
            return db.Personaje.Count(e => e.ID == id) > 0;
        }
    }
}