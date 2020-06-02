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
        // GET: api/Posiciones
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllPosiciones()
        {
            IEnumerable<Posicion> posiciones = PosicionServ.GetAllPosiciones();
            if (posiciones.Count() > 0)
            {
                return Ok(posiciones);
            }
            return BadRequest("No se ha encontrado ninguna posicion");
        }

        // GET: api/Posiciones/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult GetPosicion(int id)
        {
            Posicion posicion = PosicionServ.GetPosicionById(id);
            if (posicion == null)
            {
                return NotFound();
            }

            return Ok(posicion);
        }

        // PUT: api/Posiciones/5
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
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Posiciones
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult PostPosicion(Posicion posicion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PosicionServ.PostPosicion(posicion);

            return Ok();
        }

        // DELETE: api/Posiciones/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult DeletePosicion(int id)
        {
            PosicionServ.DeletePosicion(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}