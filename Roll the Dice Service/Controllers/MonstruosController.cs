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
    [RoutePrefix("api/monstruos")]
    public class MonstruosController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Monstruo> MonstruoDTO = uw.RepositoryClient<Monstruo>();

        // GET: api/Monstruos
        public IEnumerable<Monstruo> GetAllMonstruos()
        {
            IEnumerable<Monstruo> monstruos = MonstruoDTO.GetAll();
            if (monstruos.Count() > 0)
            {
                return monstruos.ToList();
            }
            return monstruos;
        }

        // GET: api/Monstruos/5
        [ResponseType(typeof(Monstruo))]
        public IHttpActionResult GetMonstruo(int id)
        {
            Monstruo monstruo = db.Monstruo.Find(id);
            if (monstruo == null)
            {
                return NotFound();
            }

            return Ok(monstruo);
        }

        // PUT: api/Monstruos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonstruo(int id, Monstruo monstruo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monstruo.monstruoId)
            {
                return BadRequest();
            }

            db.Entry(monstruo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonstruoExists(id))
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

        // POST: api/Monstruos
        [ResponseType(typeof(Monstruo))]
        public IHttpActionResult PostMonstruo(Monstruo monstruo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Monstruo.Add(monstruo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = monstruo.monstruoId }, monstruo);
        }

        // DELETE: api/Monstruos/5
        [ResponseType(typeof(Monstruo))]
        public IHttpActionResult DeleteMonstruo(int id)
        {
            Monstruo monstruo = db.Monstruo.Find(id);
            if (monstruo == null)
            {
                return NotFound();
            }

            db.Monstruo.Remove(monstruo);
            db.SaveChanges();

            return Ok(monstruo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonstruoExists(int id)
        {
            return db.Monstruo.Count(e => e.monstruoId == id) > 0;
        }
    }
}