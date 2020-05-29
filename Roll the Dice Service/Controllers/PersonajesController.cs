using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Utils;

namespace Roll_the_Dice_Service.Controllers
{
    [RoutePrefix("api/personajes")]
    public class PersonajesController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Personaje> PersonajeDTO = uw.RepositoryClient<Personaje>();

        // GET: api/Personajes
        public IEnumerable<Personaje> GetAllPersonajes()
        {
            IEnumerable<Personaje> personajes = PersonajeDTO.GetAll();
            if (personajes.Count() > 0)
            {
                return personajes.ToList();
            }
            return personajes;
        }

        // GET: api/Personajes/5
        [ResponseType(typeof(Personaje))]
        public IHttpActionResult GetPersonaje(int id)
        {
            Personaje personaje = db.Personaje.Find(id);
            if (personaje == null)
            {
                return NotFound();
            }

            return Ok(personaje);
        }

        // PUT: api/Personajes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonaje(int id, Personaje personaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personaje.personajeId)
            {
                return BadRequest();
            }

            db.Entry(personaje).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

        // POST: api/Personajes
        [ResponseType(typeof(Personaje))]
        public IHttpActionResult PostPersonaje(Personaje personaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personaje.Add(personaje);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personaje.personajeId }, personaje);
        }

        // DELETE: api/Personajes/5
        [ResponseType(typeof(Personaje))]
        public IHttpActionResult DeletePersonaje(int id)
        {
            Personaje personaje = db.Personaje.Find(id);
            if (personaje == null)
            {
                return NotFound();
            }

            db.Personaje.Remove(personaje);
            db.SaveChanges();

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
            return db.Personaje.Count(e => e.personajeId == id) > 0;
        }
    }
}