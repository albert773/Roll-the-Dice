using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Roll_the_Dice_Service.Controllers
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
        public IEnumerable<Personaje> GetAllPersonajes()
        {
            IEnumerable<Personaje> personajes = this.PersonajeServ.GetAllPersonajes();
            if (personajes.Count() > 0)
            {
                return personajes.ToList();
            }
            return personajes;
        }

        /*[HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetElemento(int id)
        {
            Elemento elemento = this.PersonajeServ.GetElemento(id);
            //if (elemento.Count() > 0)
            //{
            //    return elemento.ToList();
            //}
            return Ok(elemento);
        }

        // GET: api/Personajes/5
        [HttpGet]
        [Route("{id:int}")]
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

        // GET: api/Personajes/sala/{id}
        [HttpGet]
        [Route("sala/{salaId:int}")]
        public IEnumerable<Personaje> GetAllPersonajesBySala(int salaId)
        {
            IEnumerable<Personaje> personajes = PersonajeDTO.GetAll();
            if (personajes.Count() > 0)
            {
                return personajes.ToList();
            }
            return personajes;
        }

        */// PUT: api/Personajes/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonaje(int id, Personaje personaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Personaje p = PersonajeServ.PutPersonaje(id, personaje);

            //try
            //{
            //    uw.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PersonajeExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return Ok("El personaje se ha modificado correctamente");
        }

        /*// POST: api/Personajes
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

            PersonajeDTO.Delete(id);
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
        }*/
    }
}