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
    [RoutePrefix("api/elementos")]
    public class ElementosController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Elemento> ElementoDTO = uw.RepositoryClient<Elemento>();

        // GET: api/Elementos
        [HttpGet]
        [Route("")]
        public IEnumerable<Elemento> GetAllElementos()
        {
            IEnumerable<Elemento> elementos = ElementoDTO.GetAll();
            if (elementos.Count() > 0)
            {
                return elementos.ToList();
            }
            return elementos;
        }

        // GET: api/Elementos/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Elemento))]
        public IHttpActionResult GetElemento(int id)
        {
            Elemento elemento = ElementoDTO.GetByID(id);
            if (elemento == null)
            {
                return NotFound();
            }
            return Ok(elemento);
        }

        // PUT: api/Elementos/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutElemento(int id, Elemento elemento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elemento.elementoId)
            {
                return BadRequest();
            }

            ElementoDTO.Update(elemento);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("El elemento se ha modificado correctamente");
        }

        // POST: api/Elementos
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Elemento))]
        public IHttpActionResult PostElemento(Elemento elemento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ElementoDTO.Insert(elemento);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Elementos/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Elemento))]
        public IHttpActionResult DeleteElemento(int id)
        {
            Elemento elemento = ElementoDTO.GetByID(id);
            if (elemento == null)
            {
                return NotFound();
            }

            ElementoDTO.Delete(elemento);
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

        private bool ElementoExists(int id)
        {
            return ElementoDTO.getDbSet().Count(e => e.elementoId == id) > 0;
        }
    }
}