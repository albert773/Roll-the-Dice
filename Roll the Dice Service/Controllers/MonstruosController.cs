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
        public IEnumerable<Monstruo> GetAllMonstruos()
        {
            IEnumerable<Monstruo> monstruos = MonstruoDTO.GetAll();
            if (monstruos.Count() > 0)
            {
                return monstruos.ToList();
            }
            return monstruos;
        }

        // GET: api/Monstruos/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Monstruo))]
        public IHttpActionResult GetMonstruo(int id)
        {
            Monstruo monstruo = MonstruoDTO.GetByID(id);
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

            MonstruoDTO.Update(monstruo);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonstruoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            MonstruoDTO.Insert(monstruo);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Monstruos/5
        [ResponseType(typeof(Monstruo))]
        public IHttpActionResult DeleteMonstruo(int id)
        {
            Monstruo monstruo = MonstruoDTO.GetByID(id);
            if (monstruo == null)
            {
                return NotFound();
            }

            MonstruoDTO.Delete(monstruo);
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

        private bool MonstruoExists(int id)
        {
            return MonstruoDTO.getDbSet().Count(e => e.monstruoId == id) > 0;
        }
    }
}