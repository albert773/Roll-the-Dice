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
    public class NPCController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/NPC
        public IQueryable<NPC> GetNPC()
        {
            return db.NPC;
        }

        // GET: api/NPC/5
        [ResponseType(typeof(NPC))]
        public async Task<IHttpActionResult> GetNPC(int id)
        {
            NPC nPC = await db.NPC.FindAsync(id);
            if (nPC == null)
            {
                return NotFound();
            }

            return Ok(nPC);
        }

        // PUT: api/NPC/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNPC(int id, NPC nPC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nPC.ID)
            {
                return BadRequest();
            }

            db.Entry(nPC).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NPCExists(id))
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

        // POST: api/NPC
        [ResponseType(typeof(NPC))]
        public async Task<IHttpActionResult> PostNPC(NPC nPC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NPC.Add(nPC);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NPCExists(nPC.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nPC.ID }, nPC);
        }

        // DELETE: api/NPC/5
        [ResponseType(typeof(NPC))]
        public async Task<IHttpActionResult> DeleteNPC(int id)
        {
            NPC nPC = await db.NPC.FindAsync(id);
            if (nPC == null)
            {
                return NotFound();
            }

            db.NPC.Remove(nPC);
            await db.SaveChangesAsync();

            return Ok(nPC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NPCExists(int id)
        {
            return db.NPC.Count(e => e.ID == id) > 0;
        }
    }
}