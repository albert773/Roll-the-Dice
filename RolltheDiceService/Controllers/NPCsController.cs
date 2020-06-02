using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace RolltheDiceService.Controllers
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
        public IHttpActionResult GetAllNPCs()
        {
            IEnumerable<NPC> NPCs = NPCServ.GetAllNPCs();
            if (NPCs.Count() > 0)
            {
                return Ok(NPCs);
            }
            return BadRequest("No se ha encontrado ningun NPC");
        }

        // GET: api/NPCs/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(NPC))]
        public IHttpActionResult GetNPC(int id)
        {
            NPC npc = NPCServ.GetNPCById(id);
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

            try
            {
                NPCServ.PutNPC(id, npc);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
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

            NPCServ.PostNPC(npc);

            return Ok();
        }

        // DELETE: api/NPCs/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(NPC))]
        public IHttpActionResult DeleteNPC(int id)
        {
            NPCServ.DeleteNPC(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}