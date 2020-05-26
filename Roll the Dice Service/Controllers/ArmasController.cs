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
    public class ArmasController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        // GET: api/Armas
        public IQueryable<Arma> GetArma()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return db.Arma;
        }

        // GET: api/Armas/5
        [ResponseType(typeof(Arma))]
        public IHttpActionResult GetArma(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            Arma arma = db.Arma.Find(id);
            if (arma == null)
            {
                return NotFound();
            }

            return Ok(arma);
        }

        // PUT: api/Armas/5
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

            db.Entry(arma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Armas
        [ResponseType(typeof(Arma))]
        public IHttpActionResult PostArma(Arma arma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Arma.Add(arma);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = arma.armaId }, arma);
        }

        // DELETE: api/Armas/5
        [ResponseType(typeof(Arma))]
        public IHttpActionResult DeleteArma(int id)
        {
            Arma arma = db.Arma.Find(id);
            if (arma == null)
            {
                return NotFound();
            }

            db.Arma.Remove(arma);
            db.SaveChanges();

            return Ok(arma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArmaExists(int id)
        {
            return db.Arma.Count(e => e.armaId == id) > 0;
        }
    }
}