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
        public IHttpActionResult GetAllArmaduras()
        {
            IEnumerable<Armadura> armaduras = ArmaduraServ.GetAllArmaduras();
            if (armaduras.Count() > 0)
            {
                return Ok(armaduras);
            }

            return BadRequest("No se ha encontrado ninguna armadura");
        }

        // GET: api/Armaduras/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Armadura))]
        public IHttpActionResult GetArmadura(int id)
        {
            Armadura armadura = ArmaduraServ.GetArmaduraById(id);
            if (armadura != null)
            {
                return Ok(armadura);
            }

            return NotFound();
        }

        // GET: api/armadura/personaje/{id}
        [HttpGet]
        [Route("personaje/{id:int}")]
        public IHttpActionResult GetAllArmasByPersonaje(int id)
        {
            IEnumerable<Armadura> armaduras = ArmaduraServ.GetAllArmadurasByPersonaje(id);
            if (armaduras.Count() > 0)
            {
                return Ok(armaduras);
            }

            return BadRequest("No se ha encontrado ningun armadura");
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

            try
            {
                ArmaduraServ.PutArmadura(id, armadura);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
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

            ArmaduraServ.PostArmadura(armadura);

            return Ok();
        }

        // DELETE: api/Armaduras/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Armadura))]
        public IHttpActionResult DeleteArmadura(int id)
        {
            try
            {
                ArmaduraServ.DeleteArmadura(id);
            }
            catch (System.ArgumentNullException)
            {
                return BadRequest("No existe la armadura que quieres eliminar");
            }

            return Ok("Se ha eliminado correctamente");
        }
    }
}