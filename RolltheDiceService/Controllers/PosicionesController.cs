using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace RolltheDiceService.Controllers
{
    [Authorize]
    [RoutePrefix("api/posiciones")]
    public class PosicionesController : ApiController
    {
        private IPosicionService PosicionServ;

        public PosicionesController(IPosicionService PosicionServ)
        {
            this.PosicionServ = PosicionServ;
        }

        // GET: api/posiciones
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllPosiciones()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Posicion> posiciones = PosicionServ.GetAllPosiciones();
            if (posiciones.Count() > 0)
            {
                return Ok(posiciones);
            }
            return BadRequest("No se ha encontrado ninguna posicion");
        }

        // GET: api/posiciones/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult GetPosicion(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Posicion posicion = PosicionServ.GetPosicionById(id);
            if (posicion == null)
            {
                return NotFound();
            }

            return Ok(posicion);
        }

        // GET: api/posiciones/personaje/{id}
        [HttpGet]
        [Route("personaje/{id:int}")]
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult GetPosicionByPersonaje(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Posicion posicion = PosicionServ.GetPosicionByPersonaje(id);
            if (posicion == null)
            {
                return NotFound();
            }

            return Ok(posicion);
        }

        // GET: api/posiciones/sala/{id}
        [HttpGet]
        [Route("sala/{id:int}")]
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult GetAllPosicionesBySala(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Posicion> posiciones = PosicionServ.GetAllPosicionesBySala(id);
            if (posiciones == null)
            {
                return NotFound();
            }

            return Ok(posiciones);
        }

        // PUT: api/posiciones/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPosicion(int id, Posicion posicion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != posicion.posicionId)
            {
                return BadRequest();
            }

            try
            {
                PosicionServ.PutPosicion(id, posicion);
            }
            catch (DbUpdateConcurrencyException)
            {
                return InternalServerError();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/posiciones
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult PostPosicion(Posicion posicion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                PosicionServ.PostPosicion(posicion);
            }
            catch (System.Exception)
            {
                return InternalServerError();
            }

            return Ok();
        }

        // DELETE: api/posiciones/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult DeletePosicion(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                PosicionServ.DeletePosicion(id);
            }
            catch (System.Exception)
            {
                return InternalServerError();
            }

            return Ok("Se ha eliminado correctamente");
        }
    }
}