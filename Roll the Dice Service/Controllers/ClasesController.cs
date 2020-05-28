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

namespace Roll_the_Dice_Service.Controllers
{
    public class ClasesController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        // GET: api/Clases
        public IQueryable<Clase> GetClase()
        {
            return db.Clase;
        }

        // GET: api/Clases/5
        [ResponseType(typeof(Clase))]
        public IHttpActionResult GetClase(int id)
        {
            Clase clase = db.Clase.Find(id);
            if (clase == null)
            {
                return NotFound();
            }

            return Ok(clase);
        }

        // PUT: api/Clases/5
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

            db.Entry(clase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clases
        [ResponseType(typeof(Clase))]
        public IHttpActionResult PostClase(Clase clase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clase.Add(clase);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clase.claseId }, clase);
        }

        // DELETE: api/Clases/5
        [ResponseType(typeof(Clase))]
        public IHttpActionResult DeleteClase(int id)
        {
            Clase clase = db.Clase.Find(id);
            if (clase == null)
            {
                return NotFound();
            }

            db.Clase.Remove(clase);
            db.SaveChanges();

            return Ok(clase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClaseExists(int id)
        {
            return db.Clase.Count(e => e.claseId == id) > 0;
        }
    }
}