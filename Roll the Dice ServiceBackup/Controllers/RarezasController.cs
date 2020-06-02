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
    [RoutePrefix("api/rarezas")]
    public class RarezasController : ApiController
    {
        private IRarezaService RarezaServ;

        public RarezasController(IRarezaService RarezaServ)
        {
            this.RarezaServ = RarezaServ;
        }
        // GET: api/Rarezas
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllRarezas()
        {
            IEnumerable<Rareza> rarezas = RarezaServ.GetAllRarezas();
            if (rarezas.Count() > 0)
            {
                return Ok(rarezas);
            }
            return BadRequest("No se ha podido encontrar ninguna rareza");
        }

        // GET: api/Rarezas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Rareza))]
        public IHttpActionResult GetRareza(int id)
        {
            Rareza rareza = RarezaServ.GetRarezaById(id);
            if (rareza == null)
            {
                return NotFound();
            }

            return Ok(rareza);
        }

        // PUT: api/Rarezas/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRareza(int id, Rareza rareza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rareza.rarezaId)
            {
                return BadRequest();
            }

            try
            {
                RarezaServ.PutRareza(id, rareza);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("La rareza se ha modificado correctamente");
        }

        // POST: api/Rarezas
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Rareza))]
        public IHttpActionResult PostRareza(Rareza rareza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RarezaServ.PostRareza(rareza);

            return Ok();
        }

        // DELETE: api/Rarezas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Rareza))]
        public IHttpActionResult DeleteRareza(int id)
        {
            RarezaServ.DeleteRareza(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}