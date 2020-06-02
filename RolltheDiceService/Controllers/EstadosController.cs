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
    [RoutePrefix("api/estados")]
    public class EstadosController : ApiController
    {
        private IEstadoService EstadoServ;

        public EstadosController(IEstadoService EstadoServ)
        {
            this.EstadoServ = EstadoServ;
        }

        // GET: api/Estados
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEstado()
        {
            IEnumerable<Estado> estados = EstadoServ.GetAllEstados();
            if (estados.Count() > 0)
            {
                return Ok(estados);
            }
            return BadRequest("No se ha encontrado ningun estado");
        }

        // GET: api/Estados/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Estado))]
        public IHttpActionResult GetEstado(int id)
        {
            Estado estado = EstadoServ.GetEstadoById(id);
            if (estado == null)
            {
                return NotFound();
            }

            return Ok(estado);
        }

        // PUT: api/Estados/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstado(int id, Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estado.estadoId)
            {
                return BadRequest();
            }

            try
            {
                EstadoServ.PutEstado(id, estado);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("El estado se ha modificado correctamente");
        }

        // POST: api/Estados
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Estado))]
        public IHttpActionResult PostEstado(Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EstadoServ.PostEstado(estado);

            return Ok();
        }

        // DELETE: api/Estados/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Estado))]
        public IHttpActionResult DeleteEstado(int id)
        {
            EstadoServ.DeleteEstado(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}