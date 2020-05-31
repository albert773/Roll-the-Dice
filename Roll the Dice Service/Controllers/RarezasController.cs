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
        public IEnumerable<Rareza> GetAllRarezas()
        {
            IEnumerable<Rareza> rarezas = RarezaDTO.GetAll();
            if (rarezas.Count() > 0)
            {
                return rarezas.ToList();
            }
            return rarezas;
        }

        // GET: api/Rarezas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Rareza))]
        public IHttpActionResult GetRareza(int id)
        {
            Rareza rareza = RarezaDTO.GetByID(id);
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

            RarezaDTO.Update(rareza);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RarezaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            RarezaDTO.Insert(rareza);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Rarezas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Rareza))]
        public IHttpActionResult DeleteRareza(int id)
        {
            Rareza rareza = RarezaDTO.GetByID(id);
            if (rareza == null)
            {
                return NotFound();
            }

            RarezaDTO.Delete(rareza);
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

        private bool RarezaExists(int id)
        {
            return RarezaDTO.getDbSet().Count(e => e.rarezaId == id) > 0;
        }
    }
}