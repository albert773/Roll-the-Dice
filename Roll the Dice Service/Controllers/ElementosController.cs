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
    public class ElementosController : ApiController
    {
        private RolltheDiceDBEntities db = new RolltheDiceDBEntities();

        // GET: api/Elementoes
        public IQueryable<Elemento> GetElemento()
        {
            return db.Elemento;
        }

        // GET: api/Elementoes/5
        [ResponseType(typeof(Elemento))]
        public IHttpActionResult GetElemento(int id)
        {
            Elemento elemento = db.Elemento.Find(id);
            if (elemento == null)
            {
                return NotFound();
            }

            return Ok(elemento);
        }

        // PUT: api/Elementoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutElemento(int id, Elemento elemento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elemento.elementoId)
            {
                return BadRequest();
            }

            db.Entry(elemento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementoExists(id))
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

        // POST: api/Elementoes
        [ResponseType(typeof(Elemento))]
        public IHttpActionResult PostElemento(Elemento elemento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Elemento.Add(elemento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = elemento.elementoId }, elemento);
        }

        // DELETE: api/Elementoes/5
        [ResponseType(typeof(Elemento))]
        public IHttpActionResult DeleteElemento(int id)
        {
            Elemento elemento = db.Elemento.Find(id);
            if (elemento == null)
            {
                return NotFound();
            }

            db.Elemento.Remove(elemento);
            db.SaveChanges();

            return Ok(elemento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElementoExists(int id)
        {
            return db.Elemento.Count(e => e.elementoId == id) > 0;
        }
    }
}