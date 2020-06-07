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
            Sala sala = SalaServ.GetSalaById(id);
            if (sala == null)
            {
                return NotFound();
            }

            return Ok(sala);
        }

        // GET: api/Salas/nombre/Sala 1
        [HttpGet]
        [Route("{nombre}")]
        [ResponseType(typeof(Sala))]
        public IHttpActionResult GetSalaByNombre(string nombre)
        {
            Sala sala = SalaServ.GetSalaByNombre(nombre);
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

            try
            {
                SalaServ.PutSala(id, sala);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("La sala se ha modificado correctamente");
        }

        // POST: api/salas
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Sala))]
        public IHttpActionResult PostSala(Sala sala)
        {
            Sala sala1;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                sala1 = SalaServ.PostSala(sala);
            }
            catch (System.Exception)
            {
                return InternalServerError();
            }

            return Ok(sala1);
        }

        // DELETE: api/Salas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Sala))]
        public IHttpActionResult DeleteSala(int id)
        {
            SalaServ.DeleteSala(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}