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
    public class IdiomasController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Armadura> ArmaduraDTO = uw.RepositoryClient<Armadura>();

        // GET: api/Idiomas
        public IQueryable<Idioma> GetIdioma()
        {
            return db.Idioma;
        }

        // GET: api/Idiomas/5
        [ResponseType(typeof(Idioma))]
        public IHttpActionResult GetIdioma(int id)
        {
            Idioma idioma = db.Idioma.Find(id);
            if (idioma == null)
            {
                return NotFound();
            }

            return Ok(idioma);
        }

        // PUT: api/Idiomas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIdioma(int id, Idioma idioma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != idioma.idiomaId)
            {
                return BadRequest();
            }

            db.Entry(idioma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdiomaExists(id))
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

        // POST: api/Idiomas
        [ResponseType(typeof(Idioma))]
        public IHttpActionResult PostIdioma(Idioma idioma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Idioma.Add(idioma);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = idioma.idiomaId }, idioma);
        }

        // DELETE: api/Idiomas/5
        [ResponseType(typeof(Idioma))]
        public IHttpActionResult DeleteIdioma(int id)
        {
            Idioma idioma = db.Idioma.Find(id);
            if (idioma == null)
            {
                return NotFound();
            }

            db.Idioma.Remove(idioma);
            db.SaveChanges();

            return Ok(idioma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IdiomaExists(int id)
        {
            return db.Idioma.Count(e => e.idiomaId == id) > 0;
        }
    }
}