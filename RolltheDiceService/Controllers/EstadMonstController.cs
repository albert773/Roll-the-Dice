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
    [RoutePrefix("api/estatMonsts")]
    public class EstadMonstController : ApiController
    {
        private IEstadMonstService EstadMonstServ;

        public EstadMonstController(IEstadMonstService EstadMonstServ)
        {
            this.EstadMonstServ = EstadMonstServ;
        }

        // GET: api/estatMonsts
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllEstadMonst()
        {
            IEnumerable<UnionEstatMonst> estatMonsts = EstadMonstServ.GetAllEstadMonst();
            if (estatMonsts.Count() > 0)
            {
                return Ok(estatMonsts);
            }
            return BadRequest("No se ha encontrado ningun estatMonst");
        }

        // GET: api/estatMonst/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(UnionEstatMonst))]
        public IHttpActionResult GetEstadMonstById(int id)
        {
            UnionEstatMonst estatMonst = EstadMonstServ.GetEstadMonstById(id);
            if (estatMonst == null)
            {
                return NotFound();
            }

            return Ok(estatMonst);
        }

        [HttpGet]
        [Route("monstruo/{id:int}")]
        [ResponseType(typeof(UnionEstatMonst))]
        public IHttpActionResult GetAllEstadisticasByMonstruo(int id)
        {
            IEnumerable<UnionEstatMonst> estatMonsts = EstadMonstServ.GetAllEstadisticasByMonstruo(id);
            if (estatMonsts.Count() > 0)
            {
                return NotFound();
            }

            return Ok(estatMonsts);
        }

        // PUT: api/estatMonst/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstadMonst(int id, UnionEstatMonst estatMonst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estatMonst.estadisticaId)
            {
                return BadRequest();
            }

            try
            {
                EstadMonstServ.PutEstadMonst(id, estatMonst);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("El estatMonst se ha modificado correctamente");
        }

        // POST: api/estatMonst
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(UnionEstatMonst))]
        public IHttpActionResult PostEstadMonst(UnionEstatMonst estatMonst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EstadMonstServ.PostEstadMonst(estatMonst);

            return Ok();
        }

        // POST: api/estatMonst/all
        [HttpPost]
        [Route("all")]
        [ResponseType(typeof(UnionEstatMonst))]
        public IHttpActionResult PostAllEstadMonst(List<UnionEstatMonst> estatMonst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EstadMonstServ.PostAllEstadMonst(estatMonst);

            return Ok();
        }

        // DELETE: api/estatMonst/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(UnionEstatMonst))]
        public IHttpActionResult DeleteEstadMonst(int id)
        {
            EstadMonstServ.DeleteEstadMonst(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}