using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using System;
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

        // GET: api/personajes
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllPersonajes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Personaje> personajes = PersonajeServ.GetAllPersonajes();
            if (personajes.Count() > 0)
            {
                return Ok(personajes);
            }
            return BadRequest("No se ha encontrado ningun personaje");
        }

        // GET: api/personajes/usuario/{usuarioId}
        [HttpGet]
        [Route("usuario/{usuarioId:int}")]
        public IHttpActionResult GetAllPersonajesByUsuario(int usuarioId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Personaje> personajes = PersonajeServ.GetAllPersonajesByUsuario(usuarioId);
            if (personajes.Count() > 0)
            {
                return Ok(personajes);
            }
            return BadRequest();
        }

        // GET: api/personajes/sala/{salaId}
        [HttpGet]
        [Route("sala/{salaId:int}")]
        public IHttpActionResult GetAllPersonajesBySala(int salaId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Personaje> personajes = PersonajeServ.GetAllPersonajesBySala(salaId);
            if (personajes.Count() > 0)
            {
                return Ok(personajes);
            }
            return BadRequest();
        }

        // GET: api/personajes/usuario/{email}
        [HttpGet]
        [Route("usuario/{email}")]
        public IHttpActionResult GetAllPersonajesByEmail(string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Personaje> personajes = PersonajeServ.GetAllPersonajesByEmail(email);
            if (personajes.Count() > 0)
            {
                return Ok(personajes);
            }
            return BadRequest();
        }

        // GET: api/personajes/usuario/{email}/sala/{id}
        [HttpGet]
        [Route("usuario/{email}/sala/{salaId:int}")]
        public IHttpActionResult GetPersonajeByUsuarioAndSala(string email, int salaId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Personaje personaje = PersonajeServ.GetPersonajeByUsuarioAndSala(email, salaId);
            if (personaje != null)
            {
                return Ok(personaje);
            }
            return BadRequest();
        }

        // GET: api/personajes/posicion/{id}
        [HttpGet]
        [Route("posicion/{id:int}")]
        [ResponseType(typeof(Personaje))]
        public IHttpActionResult GetPersonajeWithPosicion(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Personaje personaje = PersonajeServ.GetPersonajeWithPosicion(id);
            if (personaje == null)
            {
                return NotFound();
            }

            return Ok(personaje);
        }

        // GET: api/personajes/{id}
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Personaje))]
        public IHttpActionResult GetPersonajeById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Personaje personaje = PersonajeServ.GetPersonajeById(id);
            if (personaje == null)
            {
                return NotFound();
            }

            return Ok(personaje);
        }

        // PUT: api/personajes/{id}
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
                return InternalServerError();
            }

            return Ok("El personaje se ha modificado correctamente");
        }

        // POST: api/personajes
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Personaje))]
        public IHttpActionResult PostPersonaje(Personaje personaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                PersonajeServ.PostPersonaje(personaje);
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return Ok();
        }

        // DELETE: api/personajes/{id}
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Personaje))]
        public IHttpActionResult DeletePersonaje(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                PersonajeServ.DeletePersonaje(id);
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return Ok("Se ha eliminado correctamente");
        }
    }
}