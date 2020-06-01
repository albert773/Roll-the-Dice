using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Roll_the_Dice_Service.Controllers
{
    [Authorize]
    [RoutePrefix("api/idiomas")]
    public class IdiomasController : ApiController
    {
        private IIdiomaService IdiomaServ;

        public IdiomasController(IIdiomaService IdiomaServ)
        {
            this.IdiomaServ = IdiomaServ;
        }
        // GET: api/Idiomas
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetIdioma()
        {
            IEnumerable<Idioma> idiomas = IdiomaServ.GetAllIdiomas();
            if (idiomas.Count() > 0)
            {
                return Ok(idiomas);
            }
            return BadRequest("No se ha encontrado ningun idioma");
        }

        // GET: api/Idiomas/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Idioma))]
        public IHttpActionResult GetIdioma(int id)
        {
            Idioma idioma = IdiomaServ.GetIdiomaById(id);
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

            try
            {
                IdiomaServ.PutIdioma(id, idioma);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
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

            IdiomaServ.PostIdioma(idioma);

            return Ok();
        }

        // DELETE: api/Idiomas/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Idioma))]
        public IHttpActionResult DeleteIdioma(int id)
        {
            IdiomaServ.DeleteIdioma(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}