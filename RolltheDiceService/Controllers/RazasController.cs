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
    [RoutePrefix("api/razas")]
    public class RazasController : ApiController
    {
        private IRazaService RazaServ;

        public RazasController(IRazaService RazaServ)
        {
            this.RazaServ = RazaServ;
        }

        // GET: api/Razas
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllRazas()
        {
            IEnumerable<Raza> razas = RazaServ.GetAllRazas();
            if (razas.Count() > 0)
            {
                return Ok(razas);
            }
            return BadRequest("No se ha encontrado ninguna raza");
        }

        // GET: api/Razas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Raza))]
        public IHttpActionResult GetRaza(int id)
        {
            Raza raza = RazaServ.GetRazaById(id);
            if (raza == null)
            {
                return NotFound();
            }

            return Ok(raza);
        }

        // PUT: api/Razas/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRaza(int id, Raza raza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != raza.razaId)
            {
                return BadRequest();
            }

            try
            {
                RazaServ.PutRaza(id, raza);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("La raza se ha modificado correctamente");
        }

        // POST: api/Razas
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Raza))]
        public IHttpActionResult PostRaza(Raza raza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RazaServ.PostRaza(raza);

            return Ok();
        }

        // DELETE: api/Razas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Raza))]
        public IHttpActionResult DeleteRaza(int id)
        {
            RazaServ.DeleteRaza(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}