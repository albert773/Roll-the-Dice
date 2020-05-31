using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Utils;

namespace Roll_the_Dice_Service.Controllers
{
    [RoutePrefix("api/salas")]
    public class SalasController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Sala> SalaDTO = uw.RepositoryClient<Sala>();

        // GET: api/Salas
        [HttpGet]
        [Route("")]
        public IEnumerable<Sala> GetAllUsuarios()
        {
            IEnumerable<Sala> salas = SalaDTO.GetAll();
            if (salas.Count() > 0)
            {
                return salas.ToList();
            }
            return salas;
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
            if (disposing)
            {
                uw.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalaExists(int id)
        {
            return SalaDTO.getDbSet().Count(e => e.salaId == id) > 0;
        }
    }
}