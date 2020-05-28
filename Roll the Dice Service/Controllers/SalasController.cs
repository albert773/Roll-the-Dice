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
    public class SalasController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        // GET: api/Salas
        public IQueryable<Sala> GetSala()
        {
            return db.Sala;
        }

        // GET: api/Salas/5
        [ResponseType(typeof(Sala))]
        public IHttpActionResult GetSala(int id)
        {
            Sala sala = db.Sala.Find(id);
            if (sala == null)
            {
                return NotFound();
            }

            return Ok(sala);
        }

        // PUT: api/Salas/5
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

            db.Entry(sala).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Salas
        [ResponseType(typeof(Sala))]
        public IHttpActionResult PostSala(Sala sala)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sala.Add(sala);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sala.salaId }, sala);
        }

        // DELETE: api/Salas/5
        [ResponseType(typeof(Sala))]
        public IHttpActionResult DeleteSala(int id)
        {
            Sala sala = db.Sala.Find(id);
            if (sala == null)
            {
                return NotFound();
            }

            db.Sala.Remove(sala);
            db.SaveChanges();

            return Ok(sala);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalaExists(int id)
        {
            return db.Sala.Count(e => e.salaId == id) > 0;
        }
    }
}