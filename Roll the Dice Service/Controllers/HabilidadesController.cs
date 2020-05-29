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
    [RoutePrefix("api/habilidades")]
    public class HabilidadesController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Habilidad> HabilidadDTO = uw.RepositoryClient<Habilidad>();

        // GET: api/Habilidades
        [HttpGet]
        [Route("")]
        public IEnumerable<Habilidad> GetAllHabilidades()
        {
            IEnumerable<Habilidad> habilidad = HabilidadDTO.GetAll();
            if (habilidad.Count() > 0)
            {
                return habilidad.ToList();
            }
            return habilidad;
        }

        // GET: api/Habilidades/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Habilidad))]
        public IHttpActionResult GetHabilidad(int id)
        {
            Habilidad habilidad = HabilidadDTO.GetByID(id);
            if (habilidad == null)
            {
                return NotFound();
            }

            return Ok(habilidad);
        }

        // PUT: api/Habilidades/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHabilidad(int id, Habilidad habilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != habilidad.habilidadId)
            {
                return BadRequest();
            }

            HabilidadDTO.Update(habilidad);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabilidadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("la habilidad se ha modificado correctamente");
        }

        // POST: api/Habilidades
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Habilidad))]
        public IHttpActionResult PostHabilidad(Habilidad habilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HabilidadDTO.Insert(habilidad);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Habilidades/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Habilidad))]
        public IHttpActionResult DeleteHabilidad(int id)
        {
            Habilidad habilidad = HabilidadDTO.GetByID(id);
            if (habilidad == null)
            {
                return NotFound();
            }

            HabilidadDTO.Delete(habilidad);
            uw.SaveChanges();

            return Ok(habilidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uw.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HabilidadExists(int id)
        {
            return HabilidadDTO.getDbSet().Count(e => e.habilidadId == id) > 0;
        }
    }
}