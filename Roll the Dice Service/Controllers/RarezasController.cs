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
    [RoutePrefix("api/rarezas")]
    public class RarezasController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Rareza> RarezaDTO = uw.RepositoryClient<Rareza>();

        // GET: api/Rarezas
        public IEnumerable<Rareza> GetAllRarezas()
        {
            IEnumerable<Rareza> rarezas = RarezaDTO.GetAll();
            if (rarezas.Count() > 0)
            {
                return rarezas.ToList();
            }
            return rarezas;
        }

        // GET: api/Rarezas/5
        [ResponseType(typeof(Rareza))]
        public IHttpActionResult GetRareza(int id)
        {
            Rareza rareza = db.Rareza.Find(id);
            if (rareza == null)
            {
                return NotFound();
            }

            return Ok(rareza);
        }

        // PUT: api/Rarezas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRareza(int id, Rareza rareza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rareza.rarezaId)
            {
                return BadRequest();
            }

            db.Entry(rareza).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RarezaExists(id))
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

        // POST: api/Rarezas
        [ResponseType(typeof(Rareza))]
        public IHttpActionResult PostRareza(Rareza rareza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rareza.Add(rareza);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rareza.rarezaId }, rareza);
        }

        // DELETE: api/Rarezas/5
        [ResponseType(typeof(Rareza))]
        public IHttpActionResult DeleteRareza(int id)
        {
            Rareza rareza = db.Rareza.Find(id);
            if (rareza == null)
            {
                return NotFound();
            }

            db.Rareza.Remove(rareza);
            db.SaveChanges();

            return Ok(rareza);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RarezaExists(int id)
        {
            return db.Rareza.Count(e => e.rarezaId == id) > 0;
        }
    }
}