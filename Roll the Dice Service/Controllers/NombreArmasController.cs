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
    [RoutePrefix("api/nombreArmas")]
    public class NombreArmasController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<NombreArma> NombreArmaDTO = uw.RepositoryClient<NombreArma>();

        // GET: api/NombreArmas
        public IEnumerable<NombreArma> GetAllNombreArmas()
        {
            IEnumerable<NombreArma> nombreArmas = NombreArmaDTO.GetAll();
            if (nombreArmas.Count() > 0)
            {
                return nombreArmas.ToList();
            }
            return nombreArmas;
        }

        // GET: api/NombreArmas/5
        [ResponseType(typeof(NombreArma))]
        public IHttpActionResult GetNombreArma(int id)
        {
            NombreArma nombreArma = db.NombreArma.Find(id);
            if (nombreArma == null)
            {
                return NotFound();
            }

            return Ok(nombreArma);
        }

        // PUT: api/NombreArmas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNombreArma(int id, NombreArma nombreArma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nombreArma.nombreArmaId)
            {
                return BadRequest();
            }

            db.Entry(nombreArma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NombreArmaExists(id))
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

        // POST: api/NombreArmas
        [ResponseType(typeof(NombreArma))]
        public IHttpActionResult PostNombreArma(NombreArma nombreArma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NombreArma.Add(nombreArma);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nombreArma.nombreArmaId }, nombreArma);
        }

        // DELETE: api/NombreArmas/5
        [ResponseType(typeof(NombreArma))]
        public IHttpActionResult DeleteNombreArma(int id)
        {
            NombreArma nombreArma = db.NombreArma.Find(id);
            if (nombreArma == null)
            {
                return NotFound();
            }

            db.NombreArma.Remove(nombreArma);
            db.SaveChanges();

            return Ok(nombreArma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NombreArmaExists(int id)
        {
            return db.NombreArma.Count(e => e.nombreArmaId == id) > 0;
        }
    }
}