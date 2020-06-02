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
    [RoutePrefix("api/estatPerso")]
    public class EstadPersoController : ApiController
    {
        private IEstadPersoService EstadPersoServ;

        public EstadPersoController(IEstadPersoService EstadPersoServ)
        {
            this.EstadPersoServ = EstadPersoServ;
        }

        // GET: api/estatPerso
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllEstatPerso()
        {
            IEnumerable<UnionEstatPerso> estatPerso = EstadPersoServ.GetAllEstatPerso();
            if (estatPerso.Count() > 0)
            {
                return Ok(estatPerso);
            }
            return BadRequest("No se ha encontrado ningun estatPerso");
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(UnionEstatPerso))]
        public IHttpActionResult GetEstadMonstById(int id)
        {
            UnionEstatPerso estatPerso = EstadPersoServ.GetEstatPersoById(id);
            if (estatPerso == null)
            {
                return NotFound();
            }

            return Ok(estatPerso);
        }

        // GET: api/estatPerso/5
        [HttpGet]
        [Route("personaje/{id:int}")]
        [ResponseType(typeof(UnionEstatPerso))]
        public IHttpActionResult GetAllEstadByPersonaje(int id)
        {
            IEnumerable<UnionEstatPerso> estatPerso = EstadPersoServ.GetAllEstadByPersonaje(id);
            if (estatPerso.Count() > 0)
            {
                return NotFound();
            }

            return Ok(estatPerso);
        }

        // PUT: api/estatPerso/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstatPerso(int id, UnionEstatPerso estatPerso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estatPerso.estadisticaId)
            {
                return BadRequest();
            }

            try
            {
                EstadPersoServ.PutEstatPerso(id, estatPerso);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("El estatPerso se ha modificado correctamente");
        }

        // POST: api/Items
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(UnionEstatPerso))]
        public IHttpActionResult PostEstatPerso(UnionEstatPerso estatPerso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EstadPersoServ.PostEstatPerso(estatPerso);

            return Ok();
        }

        // DELETE: api/Items/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(UnionEstatPerso))]
        public IHttpActionResult DeleteEstatPerso(int id)
        {
            EstadPersoServ.DeleteEstatPerso(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}
