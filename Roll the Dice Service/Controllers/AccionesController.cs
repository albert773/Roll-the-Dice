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
    [RoutePrefix("api/acciones")]
    public class AccionesController : ApiController
    {
        private IAccionService AccionServ;

        public AccionesController(IAccionService AccionServ)
        {
            this.AccionServ = AccionServ;
        }

        // GET: api/Acciones
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllAcciones()
        {
            IEnumerable<Accion> acciones = AccionServ.GetAllAcciones();
            if (acciones.Count() > 0)
            {
                return Ok(acciones);
            }
            else
            {
                return BadRequest("No se ha encontrado ninguna accion");
            }
        }

        // GET: api/Acciones/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Accion))]
        public IHttpActionResult GetAccion(int id)
        {
            Accion accion = accion = AccionServ.GetAccionById(id);
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

            try
            {
                AccionServ.PutAccion(id, accion);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
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

            AccionServ.PostAccion(accion);

            return Ok(accion);
        }

        // DELETE: api/Acciones/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Accion))]
        public IHttpActionResult DeleteAccion(int id)
        {
            AccionServ.DeleteAccion(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}