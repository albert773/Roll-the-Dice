using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Roll_the_Dice_Service.Controllers
{
    [RoutePrefix("api/mapas")]
    public class MapasController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Mapa> MapaDTO = uw.RepositoryClient<Mapa>();

        // GET: api/Mapas
        [HttpGet]
        [Route("")]
        public IEnumerable<Mapa> GetAllMapas()
        {
            IEnumerable<Mapa> mapas = MapaDTO.GetAll();
            if (mapas.Count() > 0)
            {
                return mapas.ToList();
            }
            return mapas;
        }

        // GET: api/Mapas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Mapa))]
        public IHttpActionResult GetMapa(int id)
        {
            Mapa mapa = MapaDTO.GetByID(id);
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

            MapaDTO.Update(mapa);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            MapaDTO.Insert(mapa);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Mapas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Mapa))]
        public IHttpActionResult DeleteMapa(int id)
        {
            Mapa mapa = MapaDTO.GetByID(id);
            if (mapa == null)
            {
                return NotFound();
            }

            MapaDTO.Delete(mapa);
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

        private bool MapaExists(int id)
        {
            return MapaDTO.getDbSet().Count(e => e.mapaId == id) > 0;
        }
    }
}