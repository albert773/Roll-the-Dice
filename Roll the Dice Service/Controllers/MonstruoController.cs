using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Roll_the_Dice_Service.Models;

namespace Roll_the_Dice_Service.Controllers
{
    public class MonstruoController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Monstruo
        public IQueryable<Monstruo> GetMonstruo()
        {
            return db.Monstruo;
        }

        // GET: api/Monstruo/5
        [ResponseType(typeof(Monstruo))]
        public async Task<IHttpActionResult> GetMonstruo(int id)
        {
            Monstruo monstruo = await db.Monstruo.FindAsync(id);
            if (monstruo == null)
            {
                return NotFound();
            }

            return Ok(monstruo);
        }

        // PUT: api/Monstruo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMonstruo(int id, Monstruo monstruo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monstruo.ID)
            {
                return BadRequest();
            }

            db.Entry(monstruo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

        // POST: api/Monstruo
        [ResponseType(typeof(Monstruo))]
        public async Task<IHttpActionResult> PostMonstruo(Monstruo monstruo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Monstruo.Add(monstruo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MonstruoExists(monstruo.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = monstruo.ID }, monstruo);
        }

        // DELETE: api/Monstruo/5
        [ResponseType(typeof(Monstruo))]
        public async Task<IHttpActionResult> DeleteMonstruo(int id)
        {
            Monstruo monstruo = await db.Monstruo.FindAsync(id);
            if (monstruo == null)
            {
                return NotFound();
            }

            db.Monstruo.Remove(monstruo);
            await db.SaveChangesAsync();

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
            return db.Monstruo.Count(e => e.ID == id) > 0;
        }
    }
}