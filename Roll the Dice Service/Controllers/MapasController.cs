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
    [RoutePrefix("api/mapas")]
    public class MapasController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Mapa> MapaDTO = uw.RepositoryClient<Mapa>();

        // GET: api/Mapas
        public IEnumerable<Mapa> GetAllMapas()
        {
            IEnumerable<Mapa> mapas = MapaDTO.GetAll();
            if (mapas.Count() > 0)
            {
                return mapas.ToList();
            }
            return mapas;
        }

        // GET: api/Mapas/5
        [ResponseType(typeof(Mapa))]
        public IHttpActionResult GetMapa(int id)
        {
            Mapa mapa = db.Mapa.Find(id);
            if (mapa == null)
            {
                return NotFound();
            }

            return Ok(mapa);
        }

        // PUT: api/Mapas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMapa(int id, Mapa mapa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mapa.mapaId)
            {
                return BadRequest();
            }

            db.Entry(mapa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapaExists(id))
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

        // POST: api/Mapas
        [ResponseType(typeof(Mapa))]
        public IHttpActionResult PostMapa(Mapa mapa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mapa.Add(mapa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mapa.mapaId }, mapa);
        }

        // DELETE: api/Mapas/5
        [ResponseType(typeof(Mapa))]
        public IHttpActionResult DeleteMapa(int id)
        {
            Mapa mapa = db.Mapa.Find(id);
            if (mapa == null)
            {
                return NotFound();
            }

            db.Mapa.Remove(mapa);
            db.SaveChanges();

            return Ok(mapa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MapaExists(int id)
        {
            return db.Mapa.Count(e => e.mapaId == id) > 0;
        }
    }
}