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
    [RoutePrefix("api/inventarios")]
    public class InventariosController : ApiController
    {
        private IInventarioService InventarioServ;

        public InventariosController(IInventarioService InventarioServ)
        {
            this.InventarioServ = InventarioServ;
        }

        // GET: api/Inventarios
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetInventario()
        {
            IEnumerable<Inventario> inventarios = InventarioServ.GetAllInventarios();
            if (inventarios.Count() > 0)
            {
                return Ok(inventarios);
            }

            return BadRequest("No se ha encontrado ningun inventario");
        }

        [HttpGet]
        [Route("personaje/{id:int}")]
        public IHttpActionResult GetInventarioByPersonaje(int id)
        {
            Inventario inventario = InventarioServ.GetInventarioByPersonaje(id);
            if (inventario == null)
            {
                return NotFound();
            }

            return Ok(inventario);
        }

        // GET: api/Inventarios/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Inventario))]
        public IHttpActionResult GetInventario(int id)
        {
            Inventario inventario = InventarioServ.GetInventarioById(id);
            if (inventario == null)
            {
                return NotFound();
            }

            return Ok(inventario);
        }

        // PUT: api/Inventarios/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventario(int id, Inventario inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventario.inventarioId)
            {
                return BadRequest();
            }

            try
            {
                InventarioServ.PutInventario(id, inventario);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("El inventario se ha modificado correctamente");
        }

        // POST: api/Inventarios
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Inventario))]
        public IHttpActionResult PostInventario(Inventario inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            InventarioServ.PostInventario(inventario);

            return Ok();
        }

        // DELETE: api/Inventarios/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Inventario))]
        public IHttpActionResult DeleteInventario(int id)
        {
            InventarioServ.DeleteInventario(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}