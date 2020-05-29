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
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Personaje> PersonajeDTO = uw.RepositoryClient<Personaje>();

        // GET: api/Personajes
        [HttpGet]
        [Route("")]
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
            Personaje personaje = PersonajeDTO.GetByID(id);
            if (personaje == null)
            {
                return NotFound();
            }

            return Ok(personaje);
        }

        // PUT: api/Personajes/5
        [HttpPut]
        [Route("{id:int}")]
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

            PersonajeDTO.Update(personaje);

            try
            {
                uw.SaveChanges();
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

            return Ok("El personaje se ha modificado correctamente");
        }

        // POST: api/Personajes
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Personaje))]
        public IHttpActionResult PostPersonaje(Personaje personaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonajeDTO.Insert(personaje);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Personajes/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Personaje))]
        public IHttpActionResult DeletePersonaje(int id)
        {
            Personaje personaje = PersonajeDTO.GetByID(id);
            if (personaje == null)
            {
                return NotFound();
            }

            PersonajeDTO.Delete(personaje);
            uw.SaveChanges();

            return Ok("Se ha eliminado correctamente");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uw.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonajeExists(int id)
        {
            return PersonajeDTO.getDbSet().Count(e => e.personajeId == id) > 0;
        }
    }
}