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
    [RoutePrefix("api/inventarios")]
    public class InventariosController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Inventario> InventarioDTO = uw.RepositoryClient<Inventario>();

        // GET: api/Inventarios
        [HttpGet]
        [Route("")]
        public IEnumerable<Inventario> GetInventario()
        {
            IEnumerable<Inventario> inventarios = InventarioDTO.GetAll();
            if (inventarios.Count() > 0)
            {
                return inventarios.ToList();
            }
            return inventarios;
        }

        // GET: api/Inventarios/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Inventario))]
        public IHttpActionResult GetInventario(int id)
        {
            Inventario inventario = InventarioDTO.GetByID(id);
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

            InventarioDTO.Update(inventario);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            InventarioDTO.Insert(inventario);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Inventarios/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Inventario))]
        public IHttpActionResult DeleteInventario(int id)
        {
            Inventario inventario = InventarioDTO.GetByID(id);
            if (inventario == null)
            {
                return NotFound();
            }

            InventarioDTO.Delete(inventario);
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

        private bool InventarioExists(int id)
        {
            return InventarioDTO.getDbSet().Count(e => e.inventarioId == id) > 0;
        }
    }
}