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
    public class NombreArmadurasController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        // GET: api/NombreArmaduras
        public IQueryable<NombreArmadura> GetNombreArmadura()
        {
            return db.NombreArmadura;
        }

        // GET: api/NombreArmaduras/5
        [ResponseType(typeof(NombreArmadura))]
        public IHttpActionResult GetNombreArmadura(int id)
        {
            NombreArmadura nombreArmadura = db.NombreArmadura.Find(id);
            if (nombreArmadura == null)
            {
                return NotFound();
            }

            return Ok(nombreArmadura);
        }

        // PUT: api/NombreArmaduras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNombreArmadura(int id, NombreArmadura nombreArmadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nombreArmadura.nombreArmaduraId)
            {
                return BadRequest();
            }

            db.Entry(nombreArmadura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NombreArmaduraExists(id))
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

        // POST: api/NombreArmaduras
        [ResponseType(typeof(NombreArmadura))]
        public IHttpActionResult PostNombreArmadura(NombreArmadura nombreArmadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NombreArmadura.Add(nombreArmadura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nombreArmadura.nombreArmaduraId }, nombreArmadura);
        }

        // DELETE: api/NombreArmaduras/5
        [ResponseType(typeof(NombreArmadura))]
        public IHttpActionResult DeleteNombreArmadura(int id)
        {
            NombreArmadura nombreArmadura = db.NombreArmadura.Find(id);
            if (nombreArmadura == null)
            {
                return NotFound();
            }

            db.NombreArmadura.Remove(nombreArmadura);
            db.SaveChanges();

            return Ok(nombreArmadura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NombreArmaduraExists(int id)
        {
            return db.NombreArmadura.Count(e => e.nombreArmaduraId == id) > 0;
        }
    }
}