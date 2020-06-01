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
    [RoutePrefix("api/habilidades")]
    public class HabilidadesController : ApiController
    {
        private IHabilidadService HabilidadServ;

        public HabilidadesController(IHabilidadService HabilidadServ)
        {
            this.HabilidadServ = HabilidadServ;
        }

        // GET: api/Habilidades
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllHabilidades()
        {
            IEnumerable<Habilidad> habilidad = HabilidadServ.GetAllHabilidades();
            if (habilidad.Count() > 0)
            {
                return Ok(habilidad);
            }
            return BadRequest("No se ha encontrado ninguna habilidad");
        }

        // GET: api/Habilidades/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Habilidad))]
        public IHttpActionResult GetHabilidad(int id)
        {
            Habilidad habilidad = HabilidadServ.GetHabilidadById(id);
            if (habilidad == null)
            {
                return NotFound();
            }

            return Ok(habilidad);
        }

        // PUT: api/Habilidades/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHabilidad(int id, Habilidad habilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != habilidad.habilidadId)
            {
                return BadRequest();
            }

            try
            {
                HabilidadServ.PutHabilidad(id, habilidad);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("La habilidad se ha modificado correctamente");
        }

        // POST: api/Habilidades
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Habilidad))]
        public IHttpActionResult PostHabilidad(Habilidad habilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HabilidadServ.PostHabilidad(habilidad);

            return Ok();
        }

        // DELETE: api/Habilidades/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Habilidad))]
        public IHttpActionResult DeleteHabilidad(int id)
        {
            HabilidadServ.DeleteHabilidad(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}