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
    [RoutePrefix("api/estadisticas")]
    public class EstadisticasController : ApiController
    {
        private IEstadisticaService EstadisticaServ;

        public EstadisticasController(IEstadisticaService EstadisticaServ)
        {
            this.EstadisticaServ = EstadisticaServ;
        }

        // GET: api/Estadisticas
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEstadistica()
        {
            IEnumerable<Estadistica> estadisticas = EstadisticaServ.GetAllEstadisticas();
            if (estadisticas.Count() > 0)
            {
                return Ok(estadisticas);
            }
            return BadRequest("No se ha encontrado ninguna estadistica");
        }

        // GET: api/Estadisticas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Estadistica))]
        public IHttpActionResult GetEstadistica(int id)
        {
            Estadistica estadistica = EstadisticaServ.GetEstadisticaById(id);
            if (estadistica == null)
            {
                return NotFound();
            }
            return Ok(estadistica);
        }

        // PUT: api/Estadisticas/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstadistica(int id, Estadistica estadistica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadistica.estadisticaId)
            {
                return BadRequest();
            }

            try
            {
                EstadisticaServ.PutEstadistica(id, estadistica);
            }
            catch (DbUpdateConcurrencyException)
            {
                  throw;
            }

            return Ok("La estadistica se ha modificado correctamente");
        }

        // POST: api/Estadisticas
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Estadistica))]
        public IHttpActionResult PostEstadistica(Estadistica estadistica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EstadisticaServ.PostEstadistica(estadistica);

            return Ok();
        }

        // DELETE: api/Estadisticas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Estadistica))]
        public IHttpActionResult DeleteEstadistica(int id)
        {
            EstadisticaServ.DeleteEstadistica(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}