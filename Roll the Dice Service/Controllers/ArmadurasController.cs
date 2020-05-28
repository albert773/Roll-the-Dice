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

namespace Roll_the_Dice_Service.Controllers
{
    public class ArmadurasController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        // GET: api/Armaduras
        public IQueryable<Armadura> GetArmadura()
        {
            return db.Armadura;
        }

        // GET: api/Armaduras/5
        [ResponseType(typeof(Armadura))]
        public IHttpActionResult GetArmadura(int id)
        {
            Armadura armadura = db.Armadura.Find(id);
            if (armadura == null)
            {
                return NotFound();
            }

            return Ok(armadura);
        }

        // PUT: api/Armaduras/5
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

            db.Entry(armadura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Armaduras
        [ResponseType(typeof(Armadura))]
        public IHttpActionResult PostArmadura(Armadura armadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Armadura.Add(armadura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = armadura.armaduraId }, armadura);
        }

        // DELETE: api/Armaduras/5
        [ResponseType(typeof(Armadura))]
        public IHttpActionResult DeleteArmadura(int id)
        {
            Armadura armadura = db.Armadura.Find(id);
            if (armadura == null)
            {
                return NotFound();
            }

            db.Armadura.Remove(armadura);
            db.SaveChanges();

            return Ok(armadura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArmaduraExists(int id)
        {
            return db.Armadura.Count(e => e.armaduraId == id) > 0;
        }
    }
}