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
    [RoutePrefix("api/nombreArmaduras")]
    public class NombreArmadurasController : ApiController
    {
        private INombreArmaduraService NombreArmaduraServ;

        public NombreArmadurasController(INombreArmaduraService NombreArmaduraServ)
        {
            this.NombreArmaduraServ = NombreArmaduraServ;
        }
        // GET: api/NombreArmaduras
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllNombreArmaduras()
        {
            IEnumerable<NombreArmadura> nombreArmaduras = NombreArmaduraServ.GetAllNombreArmaduras();
            if (nombreArmaduras.Count() > 0)
            {
                return Ok(nombreArmaduras);
            }
            return BadRequest("No se ha encontrado ningun nombreArmaduras");
        }

        // GET: api/NombreArmaduras/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(NombreArmadura))]
        public IHttpActionResult GetNombreArmadura(int id)
        {
            NombreArmadura nombreArmadura = NombreArmaduraServ.GetNombreArmaduraById(id);
            if (nombreArmadura == null)
            {
                return NotFound();
            }

            return Ok(nombreArmadura);
        }

        // PUT: api/NombreArmaduras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNombreArmadura(int id, NombreArmadura nombreArmadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nombreArmadura.nombreArmaduraId)
            {
                return BadRequest();
            }
            
            try
            {
                NombreArmaduraServ.PutNombreArmadura(id, nombreArmadura);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("El nombreArmadura se ha modificado correctamente");
        }

        // POST: api/NombreArmaduras
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(NombreArmadura))]
        public IHttpActionResult PostNombreArmadura(NombreArmadura nombreArmadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NombreArmaduraServ.PostNombreArmadura(nombreArmadura);

            return Ok();
        }

        // DELETE: api/NombreArmaduras/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(NombreArmadura))]
        public IHttpActionResult DeleteNombreArmadura(int id)
        {
            NombreArmaduraServ.DeleteNombreArmadura(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}