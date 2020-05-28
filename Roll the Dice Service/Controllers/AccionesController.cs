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
    public class AccionesController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        // GET: api/Acciones
        public IQueryable<Accion> GetAccion()
        {
            return db.Accion;
        }

        // GET: api/Acciones/5
        [ResponseType(typeof(Accion))]
        public IHttpActionResult GetAccion(int id)
        {
            Accion accion = db.Accion.Find(id);
            if (accion == null)
            {
                return NotFound();
            }

            return Ok(accion);
        }

        // PUT: api/Acciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccion(int id, Accion accion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accion.accionId)
            {
                return BadRequest();
            }

            db.Entry(accion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccionExists(id))
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

        // POST: api/Acciones
        [ResponseType(typeof(Accion))]
        public IHttpActionResult PostAccion(Accion accion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accion.Add(accion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accion.accionId }, accion);
        }

        // DELETE: api/Acciones/5
        [ResponseType(typeof(Accion))]
        public IHttpActionResult DeleteAccion(int id)
        {
            Accion accion = db.Accion.Find(id);
            if (accion == null)
            {
                return NotFound();
            }

            db.Accion.Remove(accion);
            db.SaveChanges();

            return Ok(accion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccionExists(int id)
        {
            return db.Accion.Count(e => e.accionId == id) > 0;
        }
    }
}