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
    [RoutePrefix("api/mapas")]
    public class MapasController : ApiController
    {
        private IMapaService MapaServ;

        public MapasController(IMapaService MapaServ)
        {
            this.MapaServ = MapaServ;
        }

        // GET: api/Mapas
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllMapas()
        {
            IEnumerable<Mapa> mapas = MapaServ.GetAllMapas();
            if (mapas.Count() > 0)
            {
                return Ok(mapas);
            }
            return BadRequest("No se ha encontrado ningun mapa");
        }

        // GET: api/Mapas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Mapa))]
        public IHttpActionResult GetMapa(int id)
        {
            Mapa mapa = MapaServ.GetMapaById(id);
            if (mapa == null)
            {
                return NotFound();
            }

            return Ok(mapa);
        }

        // PUT: api/Mapas/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMapa(int id, Mapa mapa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mapa.mapaId)
            {
                return BadRequest();
            }

            try
            {
                MapaServ.PutMapa(id, mapa);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("El mapa se ha modificado correctamente");
        }

        // POST: api/Mapas
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Mapa))]
        public IHttpActionResult PostMapa(Mapa mapa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MapaServ.PostMapa(mapa);

            return Ok();
        }

        // DELETE: api/Mapas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Mapa))]
        public IHttpActionResult DeleteMapa(int id)
        {
            MapaServ.DeleteMapa(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}