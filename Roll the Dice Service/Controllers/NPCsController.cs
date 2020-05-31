using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Roll_the_Dice_Service.Controllers
{
    [Authorize]
    [RoutePrefix("api/NPCs")]
    public class NPCsController : ApiController
    {
        private INPCService NPCServ;

        public NPCsController(INPCService NPCServ)
        {
            this.NPCServ = NPCServ;
        }
        // GET: api/NPCs
        [HttpGet]
        [Route("")]
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
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(NPC))]
        public IHttpActionResult GetNPC(int id)
        {
            NPC npc = NPCDTO.GetByID(id);
            if (npc == null)
            {
                return NotFound();
            }

            return Ok(npc);
        }

        // PUT: api/NPCs/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNPC(int id, NPC npc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != npc.NPCId)
            {
                return BadRequest();
            }

            NPCDTO.Update(npc);

            try
            {
                uw.SaveChanges();
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

            return Ok("El usuario se ha modificado correctamente");
        }

        // POST: api/NPCs
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(NPC))]
        public IHttpActionResult PostNPC(NPC npc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NPCDTO.Insert(npc);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/NPCs/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(NPC))]
        public IHttpActionResult DeleteNPC(int id)
        {
            NPC npc = NPCDTO.GetByID(id);
            if (npc == null)
            {
                return NotFound();
            }

            NPCDTO.Delete(npc);
            uw.SaveChanges();

            return Ok("Se ha eliminado correctamente");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uw.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NPCExists(int id)
        {
            return NPCDTO.getDbSet().Count(e => e.NPCId == id) > 0;
        }
    }
}