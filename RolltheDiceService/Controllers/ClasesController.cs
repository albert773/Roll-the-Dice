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
    [RoutePrefix("api/clases")]
    public class ClasesController : ApiController
    {
        private IClaseService ClaseServ;

        public ClasesController(IClaseService ClaseServ)
        {
            this.ClaseServ = ClaseServ;
        }

        // GET: api/Clases
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetClase()
        {
            IEnumerable<Clase> clases = ClaseServ.GetAllClases();
            if (clases.Count() > 0)
            {
                return Ok(clases);
            }

            return BadRequest("No se ha encontrado ninguna clase");
        }

        // GET: api/Clases/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Clase))]
        public IHttpActionResult GetClase(int id)
        {
            Clase clase = ClaseServ.GetClaseById(id);
            if (clase == null)
            {
                return NotFound();
            }
            return Ok(clase);
        }

        // PUT: api/Clases/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClase(int id, Clase clase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clase.claseId)
            {
                return BadRequest();
            }

            try
            {
                ClaseServ.PutClase(id, clase);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("La clase se ha modificado correctamente");
        }

        // POST: api/Clases
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Clase))]
        public IHttpActionResult PostClase(Clase clase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClaseServ.PostClase(clase);

            return Ok();
        }

        // DELETE: api/Clases/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Clase))]
        public IHttpActionResult DeleteClase(int id)
        {
            ClaseServ.DeleteClase(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}