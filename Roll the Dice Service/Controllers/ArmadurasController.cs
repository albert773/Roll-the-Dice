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
    [RoutePrefix("api/armaduras")]
    public class ArmadurasController : ApiController
    {
        private IArmaduraService ArmaduraServ;

        public ArmadurasController(IArmaduraService ArmaduraServ)
        {
            this.ArmaduraServ = ArmaduraServ;
        }

        // GET: api/Armaduras
        [HttpGet]
        [Route("")]
        public IEnumerable<Armadura> GetAllArmaduras()
        {
            IEnumerable<Armadura> armaduras = ArmaduraDTO.GetAll();
            if (armaduras.Count() > 0)
            {
                return armaduras.ToList();
            }
            return armaduras;
        }

        // GET: api/Armaduras/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Armadura))]
        public IHttpActionResult GetArmadura(int id)
        {
            Armadura armadura = ArmaduraDTO.GetByID(id);
            if (armadura == null)
            {
                return NotFound();
            }

            return Ok(armadura);
        }

        // PUT: api/Armaduras/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArmadura(int id, Armadura armadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != armadura.armaduraId)
            {
                return BadRequest();
            }

            ArmaduraDTO.Update(armadura);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmaduraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("La armadura se ha modificado correctamente");
        }

        // POST: api/Armaduras
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Armadura))]
        public IHttpActionResult PostArmadura(Armadura armadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ArmaduraDTO.Insert(armadura);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Armaduras/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Armadura))]
        public IHttpActionResult DeleteArmadura(int id)
        {
            Armadura armadura = ArmaduraDTO.GetByID(id);
            if (armadura == null)
            {
                return NotFound();
            }

            ArmaduraDTO.Delete(armadura);
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

        private bool ArmaduraExists(int id)
        {
            return ArmaduraDTO.getDbSet().Count(e => e.armaduraId == id) > 0;
        }
    }
}