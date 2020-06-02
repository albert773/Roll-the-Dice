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
    [RoutePrefix("api/monstruos")]
    public class MonstruosController : ApiController
    {
        private IMonstruoService MonstruoServ;

        public MonstruosController(IMonstruoService MonstruoServ)
        {
            this.MonstruoServ = MonstruoServ;
        }

        // GET: api/Monstruos
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllMonstruos()
        {
            IEnumerable<Monstruo> monstruos = MonstruoServ.GetAllMonstruos();
            if (monstruos.Count() > 0)
            {
                return Ok(monstruos);
            }
            return BadRequest("");
        }

        // GET: api/Monstruos/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Monstruo))]
        public IHttpActionResult GetMonstruo(int id)
        {
            Monstruo monstruo = MonstruoServ.GetMonstruoById(id);
            if (monstruo == null)
            {
                return NotFound();
            }

            return Ok(monstruo);
        }

        // PUT: api/Monstruos/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonstruo(int id, Monstruo monstruo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monstruo.monstruoId)
            {
                return BadRequest();
            }

            try
            {
                MonstruoServ.PutMonstruo(id, monstruo);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("El monstruo se ha modificado correctamente");
        }

        // POST: api/Monstruos
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Monstruo))]
        public IHttpActionResult PostMonstruo(Monstruo monstruo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MonstruoServ.PostMonstruo(monstruo);

            return Ok();
        }

        // DELETE: api/Monstruos/5
        [ResponseType(typeof(Monstruo))]
        public IHttpActionResult DeleteMonstruo(int id)
        {
            MonstruoServ.DeleteMonstruo(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}