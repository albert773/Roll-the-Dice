using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Roll_the_Dice_Service.Controllers
{
    [RoutePrefix("api/estadisticas")]
    public class EstadisticasController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Estadistica> EstadisticaDTO = uw.RepositoryClient<Estadistica>();

        // GET: api/Estadisticas
        [HttpGet]
        [Route("")]
        public IEnumerable<Estadistica> GetEstadistica()
        {
            IEnumerable<Estadistica> estadisticas = EstadisticaDTO.GetAll();
            if (estadisticas.Count() > 0)
            {
                return estadisticas.ToList();
            }
            return estadisticas;
        }

        // GET: api/Estadisticas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Estadistica))]
        public IHttpActionResult GetEstadistica(int id)
        {
            Estadistica estadistica = EstadisticaDTO.GetByID(id);
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

            EstadisticaDTO.Update(estadistica);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadisticaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            EstadisticaDTO.Insert(estadistica);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Estadisticas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Estadistica))]
        public IHttpActionResult DeleteEstadistica(int id)
        {
            Estadistica estadistica = EstadisticaDTO.GetByID(id);
            if (estadistica == null)
            {
                return NotFound();
            }

            EstadisticaDTO.Delete(estadistica);
            uw.SaveChanges();

            return Ok(estadistica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uw.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadisticaExists(int id)
        {
            return EstadisticaDTO.getDbSet().Count(e => e.estadisticaId == id) > 0;
        }
    }
}