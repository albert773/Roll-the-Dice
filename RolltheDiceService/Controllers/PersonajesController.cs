using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace RolltheDiceService.Controllers
{
    [Authorize]
    [RoutePrefix("api/personajes")]
    public class PersonajesController : ApiController
    {
        private IPersonajeService PersonajeServ;

        public PersonajesController(IPersonajeService PersonajeServ)
        {
            this.PersonajeServ = PersonajeServ;
        }

        // GET: api/Personajes
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllPersonajes()
        {
            IEnumerable<Personaje> personajes = PersonajeServ.GetAllPersonajes();
            if (personajes.Count() > 0)
            {
                return Ok(personajes);
            }
            return BadRequest("No se ha encontrado ningun personaje");
        }

        // GET: api/Personajes/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Personaje))]
        public IHttpActionResult GetPersonaje(int id)
        {
            Personaje personaje = PersonajeServ.GetPersonajeById(id);
            if (personaje == null)
            {
                return NotFound();
            }

            return Ok(personaje);
        }

        // GET: api/Personajes/sala/{id}
        [HttpGet]
        [Route("sala/{salaId:int}")]
        public IEnumerable<Personaje> GetAllPersonajesBySala(int salaId)
        {
            IEnumerable<Personaje> personajes = PersonajeServ.GetAllPersonajesBySala(salaId);
            if (personajes.Count() > 0)
            {
                return personajes.ToList();
            }
            return personajes;
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

            try
            {
                PersonajeServ.PutPersonaje(id, personaje);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
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

            PersonajeServ.PostPersonaje(personaje);

            return Ok();
        }

        // DELETE: api/Personajes/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Personaje))]
        public IHttpActionResult DeletePersonaje(int id)
        {
            PersonajeServ.DeletePersonaje(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}