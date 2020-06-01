using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Roll_the_Dice_Service.Controllers
{
    [Authorize]
    [RoutePrefix("api/elementos")]
    public class ElementosController : ApiController
    {
        private IElementoService ElementoServ;

        public ElementosController(IElementoService ElementoServ)
        {
            this.ElementoServ = ElementoServ;
        }

        // GET: api/Elementos
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllElementos()
        {
            IEnumerable<Elemento> elementos = ElementoServ.GetAllElementos();
            if (elementos.Count() > 0)
            {
                return Ok(elementos);
            }
            return BadRequest("No se ha encontrado ningun elemento");
        }

        // GET: api/Elementos/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Elemento))]
        public IHttpActionResult GetElemento(int id)
        {
            Elemento elemento = ElementoServ.GetElementoById(id);
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

            try
            {
                ElementoServ.PutElemento(id, elemento);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
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

            ElementoServ.PostElemento(elemento);

            return Ok();
        }

        // DELETE: api/Elementos/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Elemento))]
        public IHttpActionResult DeleteElemento(int id)
        {
            ElementoServ.DeleteElemento(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}