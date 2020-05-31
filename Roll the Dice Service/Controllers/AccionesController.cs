using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Roll_the_Dice_Service.Controllers
{
    [Authorize]
    [RoutePrefix("api/acciones")]
    public class AccionesController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Accion> AccionDTO = uw.RepositoryClient<Accion>();

        // GET: api/Acciones
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllAcciones()
        {
            IEnumerable<Accion> a = AccionDTO.GetAll();
            if (a.Count() > 0)
            {
                return Ok(a.ToList());
            }
            else
            {
                return BadRequest("Solicitud Incorrecta");
            }
        }

        // GET: api/Acciones/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Accion))]
        public IHttpActionResult GetAccion(int id)
        {
            Accion accion = accion = AccionDTO.GetByID(id);
            if (accion == null)
            {
                return BadRequest("No se ha encontrado la accion con id: " + id);
            }
            return Ok(accion);
        }

        // PUT: api/Acciones/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccion(int id, Accion accion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AccionDTO.Update(accion);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("La acción se ha modificado correctamente");
        }

        // POST: api/Acciones
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Accion))]
        public IHttpActionResult PostAccion(Accion accion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AccionDTO.Insert(accion);
            uw.SaveChanges();

            return Ok(accion);
        }

        // DELETE: api/Acciones/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Accion))]
        public IHttpActionResult DeleteAccion(int id)
        {
            Accion accion = AccionDTO.GetByID(id);
            if (accion == null)
            {
                return NotFound();
            }

            AccionDTO.Delete(accion);
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

        private bool AccionExists(int id)
        {
            return AccionDTO.getDbSet().Count(e => e.accionId == id) > 0;
        }
    }
}