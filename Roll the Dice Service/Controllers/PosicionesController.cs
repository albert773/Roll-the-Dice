using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Roll_the_Dice_Service.Controllers
{
    [RoutePrefix("api/posiciones")]
    public class PosicionesController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Posicion> PosicionDTO = uw.RepositoryClient<Posicion>();

        // GET: api/Posiciones
        [HttpGet]
        [Route("")]
        public IEnumerable<Posicion> GetAllPosiciones()
        {
            IEnumerable<Posicion> posiciones = PosicionDTO.GetAll();
            if (posiciones.Count() > 0)
            {
                return posiciones.ToList();
            }
            return posiciones;
        }

        // GET: api/Posiciones/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult GetPosicion(int id)
        {
            Posicion posicion = PosicionDTO.GetByID(id);
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

            PosicionDTO.Update(posicion);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosicionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            PosicionDTO.Insert(posicion);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Posiciones/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult DeletePosicion(int id)
        {
            Posicion posicion = PosicionDTO.GetByID(id);
            if (posicion == null)
            {
                return NotFound();
            }

            PosicionDTO.Delete(posicion);
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

        private bool PosicionExists(int id)
        {
            return PosicionDTO.getDbSet().Count(e => e.posicionId == id) > 0;
        }
    }
}