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
    [RoutePrefix("api/armas")]
    public class ArmasController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Arma> ArmaDTO = uw.RepositoryClient<Arma>();

        // GET: api/Armas
        [HttpGet]
        [Route("")]
        public IEnumerable<Arma> GetArma()
        {
            IEnumerable<Arma> armas = ArmaDTO.GetAll();
            if (armas.Count() > 0)
            {
                return armas.ToList();
            }
            return armas;
        }

        // GET: api/Armas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Arma))]
        public IHttpActionResult GetArma(int id)
        {
            Arma arma = ArmaDTO.GetByID(id);
            if (arma == null)
            {
                return NotFound();
            }
            return Ok(arma);
        }

        // PUT: api/Armas/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArma(int id, Arma arma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != arma.armaId)
            {
                return BadRequest();
            }

            ArmaDTO.Update(arma);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("El arma se ha modificado correctamente");
        }

        // POST: api/Armas
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Arma))]
        public IHttpActionResult PostArma(Arma arma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ArmaDTO.Insert(arma);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Armas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Arma))]
        public IHttpActionResult DeleteArma(int id)
        {
            Arma arma = ArmaDTO.GetByID(id);
            if (arma == null)
            {
                return NotFound();
            }

            ArmaDTO.Delete(arma);
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

        private bool ArmaExists(int id)
        {
            return ArmaDTO.getDbSet().Count(e => e.armaId == id) > 0;
        }
    }
}