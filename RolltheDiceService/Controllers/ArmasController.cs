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
    [RoutePrefix("api/armas")]
    public class ArmasController : ApiController
    {
        private IArmaService ArmaServ;

        public ArmasController(IArmaService ArmaServ)
        {
            this.ArmaServ = ArmaServ;
        }

        // GET: api/armas
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetArma()
        {
            IEnumerable<Arma> armas = ArmaServ.GetAllArmas();
            if (armas.Count() > 0)
            {
                return Ok(armas);
            }

            return BadRequest("No se ha encontrado ningun arma");
        }

        // GET: api/armas/personaje/{id}
        [HttpGet]
        [Route("personaje/{id:int}")]
        public IHttpActionResult GetAllArmasByPersonaje(int id)
        {
            IEnumerable<Arma> armas = ArmaServ.GetAllArmasByPersonaje(id);
            if (armas.Count() > 0)
            {
                return Ok(armas);
            }

            return BadRequest("No se ha encontrado ningun arma");
        }

        // GET: api/armas/{id}
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Arma))]
        public IHttpActionResult GetArma(int id)
        {
            Arma arma = ArmaServ.GetArmaById(id);
            if (arma != null)
            {
                return Ok(arma);
            }

            return BadRequest("No se ha encontrado el arma con id: " + id);
        }

        // PUT: api/Armas/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArma(int id, Arma arma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != arma.armaId)
            {
                return BadRequest();
            }

            try
            {
                ArmaServ.PutArma(id, arma);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("El arma se ha modificado correctamente");
        }

        // POST: api/Armas
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Arma))]
        public IHttpActionResult PostArma(Arma arma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ArmaServ.PostArma(arma);

            return Ok();
        }

        // DELETE: api/Armas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Arma))]
        public IHttpActionResult DeleteArma(int id)
        {
            try
            {
                ArmaServ.DeleteArma(id);
            }
            catch (System.Exception)
            {
                BadRequest("No exixste el arma a eliminar");
            }

            return Ok("Se ha eliminado correctamente");
        }
    }
}