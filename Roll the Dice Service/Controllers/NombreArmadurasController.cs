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
    [RoutePrefix("api/nombreArmaduras")]
    public class NombreArmadurasController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<NombreArmadura> NombreArmaduraDTO = uw.RepositoryClient<NombreArmadura>();

        // GET: api/NombreArmaduras
        [HttpGet]
        [Route("")]
        public IEnumerable<NombreArmadura> GetAllNombreArmaduras()
        {
            IEnumerable<NombreArmadura> nombreArmaduras = NombreArmaduraDTO.GetAll();
            if (nombreArmaduras.Count() > 0)
            {
                return nombreArmaduras.ToList();
            }
            return nombreArmaduras;
        }

        // GET: api/NombreArmaduras/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(NombreArmadura))]
        public IHttpActionResult GetNombreArmadura(int id)
        {
            NombreArmadura nombreArmadura = NombreArmaduraDTO.GetByID(id);
            if (nombreArmadura == null)
            {
                return NotFound();
            }

            return Ok(nombreArmadura);
        }

        // PUT: api/NombreArmaduras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNombreArmadura(int id, NombreArmadura nombreArmadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nombreArmadura.nombreArmaduraId)
            {
                return BadRequest();
            }

            NombreArmaduraDTO.Update(nombreArmadura);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NombreArmaduraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("El nombreArmadura se ha modificado correctamente");
        }

        // POST: api/NombreArmaduras
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(NombreArmadura))]
        public IHttpActionResult PostNombreArmadura(NombreArmadura nombreArmadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NombreArmaduraDTO.Insert(nombreArmadura);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/NombreArmaduras/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(NombreArmadura))]
        public IHttpActionResult DeleteNombreArmadura(int id)
        {
            NombreArmadura nombreArmadura = NombreArmaduraDTO.GetByID(id);
            if (nombreArmadura == null)
            {
                return NotFound();
            }

            NombreArmaduraDTO.Delete(nombreArmadura);
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

        private bool NombreArmaduraExists(int id)
        {
            return NombreArmaduraDTO.getDbSet().Count(e => e.nombreArmaduraId == id) > 0;
        }
    }
}