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
    public class HabilidadesController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Armadura> ArmaduraDTO = uw.RepositoryClient<Armadura>();

        // GET: api/Habilidades
        public IQueryable<Habilidad> GetHabilidad()
        {
            return db.Habilidad;
        }

        // GET: api/Habilidades/5
        [ResponseType(typeof(Habilidad))]
        public IHttpActionResult GetHabilidad(int id)
        {
            Habilidad habilidad = db.Habilidad.Find(id);
            if (habilidad == null)
            {
                return NotFound();
            }

            return Ok(habilidad);
        }

        // PUT: api/Habilidades/5
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

            db.Entry(habilidad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Habilidades
        [ResponseType(typeof(Habilidad))]
        public IHttpActionResult PostHabilidad(Habilidad habilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Habilidad.Add(habilidad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = habilidad.habilidadId }, habilidad);
        }

        // DELETE: api/Habilidades/5
        [ResponseType(typeof(Habilidad))]
        public IHttpActionResult DeleteHabilidad(int id)
        {
            Habilidad habilidad = db.Habilidad.Find(id);
            if (habilidad == null)
            {
                return NotFound();
            }

            db.Habilidad.Remove(habilidad);
            db.SaveChanges();

            return Ok(habilidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HabilidadExists(int id)
        {
            return db.Habilidad.Count(e => e.habilidadId == id) > 0;
        }
    }
}