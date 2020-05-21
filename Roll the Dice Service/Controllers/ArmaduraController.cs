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
    public class ArmaduraController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Armadura
        public IQueryable<Armadura> GetArmadura()
        {
            return db.Armadura;
        }

        // GET: api/Armadura/5
        [ResponseType(typeof(Armadura))]
        public async Task<IHttpActionResult> GetArmadura(int id)
        {
            Armadura armadura = await db.Armadura.FindAsync(id);
            if (armadura == null)
            {
                return NotFound();
            }

            return Ok(armadura);
        }

        // PUT: api/Armadura/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArmadura(int id, Armadura armadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != armadura.ID)
            {
                return BadRequest();
            }

            db.Entry(armadura).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmaduraExists(id))
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

        // POST: api/Armadura
        [ResponseType(typeof(Armadura))]
        public async Task<IHttpActionResult> PostArmadura(Armadura armadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Armadura.Add(armadura);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArmaduraExists(armadura.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = armadura.ID }, armadura);
        }

        // DELETE: api/Armadura/5
        [ResponseType(typeof(Armadura))]
        public async Task<IHttpActionResult> DeleteArmadura(int id)
        {
            Armadura armadura = await db.Armadura.FindAsync(id);
            if (armadura == null)
            {
                return NotFound();
            }

            db.Armadura.Remove(armadura);
            await db.SaveChangesAsync();

            return Ok(armadura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArmaduraExists(int id)
        {
            return db.Armadura.Count(e => e.ID == id) > 0;
        }
    }
}