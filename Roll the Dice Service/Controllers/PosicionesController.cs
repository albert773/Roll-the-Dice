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
    [RoutePrefix("api/posiciones")]
    public class PosicionesController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Posicion> PosicionDTO = uw.RepositoryClient<Posicion>();

        // GET: api/Posiciones
        public IEnumerable<Posicion> GetAllPosiciones()
        {
            IEnumerable<Posicion> posiciones = PosicionDTO.GetAll();
            if (posiciones.Count() > 0)
            {
                return posiciones.ToList();
            }
            return posiciones;
        }

        // GET: api/Posiciones/5
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult GetPosicion(int id)
        {
            Posicion posicion = db.Posicion.Find(id);
            if (posicion == null)
            {
                return NotFound();
            }

            return Ok(posicion);
        }

        // PUT: api/Posiciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPosicion(int id, Posicion posicion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != posicion.posicionId)
            {
                return BadRequest();
            }

            db.Entry(posicion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosicionExists(id))
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

        // POST: api/Posiciones
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult PostPosicion(Posicion posicion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posicion.Add(posicion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = posicion.posicionId }, posicion);
        }

        // DELETE: api/Posiciones/5
        [ResponseType(typeof(Posicion))]
        public IHttpActionResult DeletePosicion(int id)
        {
            Posicion posicion = db.Posicion.Find(id);
            if (posicion == null)
            {
                return NotFound();
            }

            db.Posicion.Remove(posicion);
            db.SaveChanges();

            return Ok(posicion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PosicionExists(int id)
        {
            return db.Posicion.Count(e => e.posicionId == id) > 0;
        }
    }
}