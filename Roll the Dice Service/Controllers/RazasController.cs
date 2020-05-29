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
    [RoutePrefix("api/razas")]
    public class RazasController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Raza> RazaDTO = uw.RepositoryClient<Raza>();

        // GET: api/Razas
        [HttpGet]
        [Route("")]
        public IEnumerable<Raza> GetAllRazas()
        {
            IEnumerable<Raza> razas = RazaDTO.GetAll();
            if (razas.Count() > 0)
            {
                return razas.ToList();
            }
            return razas;
        }

        // GET: api/Razas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Raza))]
        public IHttpActionResult GetRaza(int id)
        {
            Raza raza = RazaDTO.GetByID(id);
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

            RazaDTO.Update(raza);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RazaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            RazaDTO.Insert(raza);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Razas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Raza))]
        public IHttpActionResult DeleteRaza(int id)
        {
            Raza raza = RazaDTO.GetByID(id);
            if (raza == null)
            {
                return NotFound();
            }

            RazaDTO.Delete(raza);
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

        private bool RazaExists(int id)
        {
            return RazaDTO.getDbSet().Count(e => e.razaId == id) > 0;
        }
    }
}