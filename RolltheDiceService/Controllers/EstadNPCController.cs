using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RolltheDiceService.Controllers
{
    [Authorize]
    [RoutePrefix("api/estatNPCs")]
    public class EstadNPCController : ApiController
    {
        private IEstadNPCService EstadNPCServ;

        public EstadNPCController(IEstadNPCService EstadNPCServ)
        {
            this.EstadNPCServ = EstadNPCServ;
        }

        // GET: api/estatNPCs
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllEstatNPC()
        {
            IEnumerable<UnionEstatNPC> estatNPCs = EstadNPCServ.GetAllEstatNPC();
            if (estatNPCs.Count() > 0)
            {
                return Ok(estatNPCs);
            }
            return BadRequest("No se ha encontrado ningun estatNPC");
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(UnionEstatNPC))]
        public IHttpActionResult GetEstadMonstById(int id)
        {
            UnionEstatNPC estatNPC = EstadNPCServ.GetEstatNPCById(id);
            if (estatNPC == null)
            {
                return NotFound();
            }

            return Ok(estatNPC);
        }

        // GET: api/estatNPC/5
        [HttpGet]
        [Route("NPC/{id:int}")]
        [ResponseType(typeof(UnionEstatNPC))]
        public IHttpActionResult GetAllEstadisticasByNPC(int id)
        {
            IEnumerable<UnionEstatNPC> estatNPCs = EstadNPCServ.GetAllEstadisticasByNPC(id);
            if (estatNPCs.Count() > 0)
            {
                return Ok(estatNPCs);
            }
            return BadRequest("No se ha encontrado ningun estatNPC");
        }

        // PUT: api/estatNPC/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstatNPC(int id, UnionEstatNPC estatNPC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estatNPC.estadisticaId)
            {
                return BadRequest();
            }

            try
            {
                EstadNPCServ.PutEstatNPC(id, estatNPC);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("El estatNPC se ha modificado correctamente");
        }

        // POST: api/estatNPC
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(UnionEstatNPC))]
        public IHttpActionResult PostEstatNPC(UnionEstatNPC estatNPC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EstadNPCServ.PostEstatNPC(estatNPC);

            return Ok();
        }

        // DELETE: api/estatNPC/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(UnionEstatNPC))]
        public IHttpActionResult DeleteEstatNPC(int id)
        {
            EstadNPCServ.DeleteEstatNPC(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}
