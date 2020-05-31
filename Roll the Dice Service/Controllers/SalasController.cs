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
    [RoutePrefix("api/salas")]
    public class SalasController : ApiController
    {
        private ISalaService SalaServ;

        public SalasController(ISalaService SalaServ)
        {
            this.SalaServ = SalaServ;
        }
        // GET: api/Salas
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllSalas()
        {
            IEnumerable<Sala> salas = SalaServ.GetAllSalas();
            if (salas.Count() > 0)
            {
                return Ok(salas);
            }
            return BadRequest("No existe ninguna sala");
        }

        // GET: api/Salas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Sala))]
        public IHttpActionResult GetSala(int id)
        {
            Sala sala = SalaDTO.GetByID(id);
            if (sala == null)
            {
                return NotFound();
            }

            return Ok(sala);
        }

        // PUT: api/Salas/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSala(int id, Sala sala)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sala.salaId)
            {
                return BadRequest();
            }

            SalaDTO.Update(sala);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("La sala se ha modificado correctamente");
        }

        // POST: api/Salas
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Sala))]
        public IHttpActionResult PostSala(Sala sala)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SalaDTO.Insert(sala);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Salas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Sala))]
        public IHttpActionResult DeleteSala(int id)
        {
            Sala sala = SalaDTO.GetByID(id);
            if (sala == null)
            {
                return NotFound();
            }

            SalaDTO.Delete(sala);
            uw.SaveChanges();

            return Ok("Se ha eliminado correctamente");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(false);
        }

        private bool SalaExists(int id)
        {
            return SalaDTO.getDbSet().Count(e => e.salaId == id) > 0;
        }
    }
}