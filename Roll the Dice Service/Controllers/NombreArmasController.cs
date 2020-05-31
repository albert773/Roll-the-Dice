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
        public IEnumerable<NombreArma> GetAllNombreArmas()
        {
            IEnumerable<NombreArma> nombreArmas = NombreArmaDTO.GetAll();
            if (nombreArmas.Count() > 0)
            {
                return nombreArmas.ToList();
            }
            return nombreArmas;
        }

        // GET: api/NombreArmas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(NombreArma))]
        public IHttpActionResult GetNombreArma(int id)
        {
            NombreArma nombreArma = NombreArmaDTO.GetByID(id);
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

            NombreArmaDTO.Update(nombreArma);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NombreArmaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            NombreArmaDTO.Insert(nombreArma);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/NombreArmas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(NombreArma))]
        public IHttpActionResult DeleteNombreArma(int id)
        {
            NombreArma nombreArma = NombreArmaDTO.GetByID(id);
            if (nombreArma == null)
            {
                return NotFound();
            }

            NombreArmaDTO.Delete(nombreArma);
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

        private bool NombreArmaExists(int id)
        {
            return NombreArmaDTO.getDbSet().Count(e => e.nombreArmaId == id) > 0;
        }
    }
}