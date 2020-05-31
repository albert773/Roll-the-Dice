using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Roll_the_Dice_Service.Controllers
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
        public IEnumerable<Estado> GetEstado()
        {
            IEnumerable<Estado> estados = EstadoDTO.GetAll();
            if (estados.Count() > 0)
            {
                return estados.ToList();
            }
            return estados;
        }

        // GET: api/Estados/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Estado))]
        public IHttpActionResult GetEstado(int id)
        {
            Estado estado = EstadoDTO.GetByID(id);
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

            EstadoDTO.Update(estado);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            EstadoDTO.Insert(estado);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Estados/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Estado))]
        public IHttpActionResult DeleteEstado(int id)
        {
            Estado estado = EstadoDTO.GetByID(id);
            if (estado == null)
            {
                return NotFound();
            }

            EstadoDTO.Delete(estado);
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

        private bool EstadoExists(int id)
        {
            return EstadoDTO.getDbSet().Count(e => e.estadoId == id) > 0;
        }
    }
}