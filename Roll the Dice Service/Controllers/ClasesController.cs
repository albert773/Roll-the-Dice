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
    [RoutePrefix("api/clases")]
    public class ClasesController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Clase> ClaseDTO = uw.RepositoryClient<Clase>();

        // GET: api/Clases
        [HttpGet]
        [Route("")]
        public IEnumerable<Clase> GetClase()
        {
            IEnumerable<Clase> clases = ClaseDTO.GetAll();
            if (clases.Count() > 0)
            {
                return clases.ToList();
            }
            return clases;
        }

        // GET: api/Clases/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Clase))]
        public IHttpActionResult GetClase(int id)
        {
            Clase clase = ClaseDTO.GetByID(id);
            if (clase == null)
            {
                return NotFound();
            }
            return Ok(clase);
        }

        // PUT: api/Clases/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClase(int id, Clase clase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clase.claseId)
            {
                return BadRequest();
            }

            ClaseDTO.Update(clase);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("La clase se ha modificado correctamente");
        }

        // POST: api/Clases
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Clase))]
        public IHttpActionResult PostClase(Clase clase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClaseDTO.Insert(clase);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Clases/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Clase))]
        public IHttpActionResult DeleteClase(int id)
        {
            Clase clase = ClaseDTO.GetByID(id);
            if (clase == null)
            {
                return NotFound();
            }

            ClaseDTO.Delete(clase);
            uw.SaveChanges();

            return Ok(clase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uw.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClaseExists(int id)
        {
            return ClaseDTO.getDbSet().Count(e => e.claseId == id) > 0;
        }
    }
}