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
    [RoutePrefix("api/nombreArmas")]
    public class NombreArmasController : ApiController
    {
        private INombreArmaService NombreArmaServ;

        public NombreArmasController(INombreArmaService NombreArmaServ)
        {
            this.NombreArmaServ = NombreArmaServ;
        }

        // GET: api/NombreArmas
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllNombreArmas()
        {
            IEnumerable<NombreArma> nombreArmas = NombreArmaServ.GetAllNombreArmas();
            if (nombreArmas.Count() > 0)
            {
                return Ok(nombreArmas);
            }
            return BadRequest("No se ha encontrado ningun nombreArma");
        }

        // GET: api/NombreArmas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(NombreArma))]
        public IHttpActionResult GetNombreArma(int id)
        {
            NombreArma nombreArma = NombreArmaServ.GetNombreArmaById(id);
            if (nombreArma == null)
            {
                return NotFound();
            }

            return Ok(nombreArma);
        }

        // PUT: api/NombreArmas/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNombreArma(int id, NombreArma nombreArma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nombreArma.nombreArmaId)
            {
                return BadRequest();
            }

            try
            {
                NombreArmaServ.PutNombreArma(id, nombreArma);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("El nombreArma se ha modificado correctamente");
        }

        // POST: api/NombreArmas
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(NombreArma))]
        public IHttpActionResult PostNombreArma(NombreArma nombreArma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NombreArmaServ.PostNombreArma(nombreArma);

            return Ok();
        }

        // DELETE: api/NombreArmas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(NombreArma))]
        public IHttpActionResult DeleteNombreArma(int id)
        {
            NombreArmaServ.DeleteNombreArma(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}