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
    [RoutePrefix("api/idiomas")]
    public class IdiomasController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Idioma> IdiomaDTO = uw.RepositoryClient<Idioma>();

        // GET: api/Idiomas
        [HttpGet]
        [Route("")]
        public IEnumerable<Idioma> GetIdioma()
        {
            IEnumerable<Idioma> idiomas = IdiomaDTO.GetAll();
            if (idiomas.Count() > 0)
            {
                return idiomas.ToList();
            }
            return idiomas;
        }

        // GET: api/Idiomas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Idioma))]
        public IHttpActionResult GetIdioma(int id)
        {
            Idioma idioma = IdiomaDTO.GetByID(id);
            if (idioma == null)
            {
                return NotFound();
            }

            return Ok(idioma);
        }

        // PUT: api/Idiomas/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIdioma(int id, Idioma idioma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != idioma.idiomaId)
            {
                return BadRequest();
            }

            IdiomaDTO.Update(idioma);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdiomaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("El idioma se ha modificado correctamente");
        }

        // POST: api/Idiomas
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Idioma))]
        public IHttpActionResult PostIdioma(Idioma idioma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdiomaDTO.Insert(idioma);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Idiomas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Idioma))]
        public IHttpActionResult DeleteIdioma(int id)
        {
            Idioma idioma = IdiomaDTO.GetByID(id);
            if (idioma == null)
            {
                return NotFound();
            }

            IdiomaDTO.Delete(idioma);
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

        private bool IdiomaExists(int id)
        {
            return IdiomaDTO.getDbSet().Count(e => e.idiomaId == id) > 0;
        }
    }
}