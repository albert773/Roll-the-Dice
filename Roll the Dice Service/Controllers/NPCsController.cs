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
    [RoutePrefix("api/NPCs")]
    public class NPCsController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<NPC> NPCDTO = uw.RepositoryClient<NPC>();

        // GET: api/NPCs
        public IEnumerable<NPC> GetAllNPCs()
        {
            IEnumerable<NPC> NPCs = NPCDTO.GetAll();
            if (NPCs.Count() > 0)
            {
                return NPCs.ToList();
            }
            return NPCs;
        }

        // GET: api/NPCs/5
        [ResponseType(typeof(NPC))]
        public IHttpActionResult GetNPC(int id)
        {
            NPC nPC = db.NPC.Find(id);
            if (nPC == null)
            {
                return NotFound();
            }

            return Ok(nPC);
        }

        // PUT: api/NPCs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNPC(int id, NPC nPC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nPC.NPCId)
            {
                return BadRequest();
            }

            db.Entry(nPC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

        // POST: api/NPCs
        [ResponseType(typeof(NPC))]
        public IHttpActionResult PostNPC(NPC nPC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NPC.Add(nPC);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nPC.NPCId }, nPC);
        }

        // DELETE: api/NPCs/5
        [ResponseType(typeof(NPC))]
        public IHttpActionResult DeleteNPC(int id)
        {
            NPC nPC = db.NPC.Find(id);
            if (nPC == null)
            {
                return NotFound();
            }

            db.NPC.Remove(nPC);
            db.SaveChanges();

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
            return db.NPC.Count(e => e.NPCId == id) > 0;
        }
    }
}