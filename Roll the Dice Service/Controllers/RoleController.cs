using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Roll_the_Dice_Service.Models;

namespace Roll_the_Dice_Service.Controllers
{
    public class RoleController : ApiController
    {
        private RolltheDiceEntities db = new RolltheDiceEntities();

        // GET: api/Role
        public IQueryable<Role> GetRole()
        {
            return db.Role;
        }

        // GET: api/Role/5
        [ResponseType(typeof(Role))]
        public async Task<IHttpActionResult> GetRole(int id)
        {
            Role role = await db.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Role/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRole(int id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.ID)
            {
                return BadRequest();
            }

            db.Entry(role).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Role
        [ResponseType(typeof(Role))]
        public async Task<IHttpActionResult> PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Role.Add(role);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoleExists(role.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = role.ID }, role);
        }

        // DELETE: api/Role/5
        [ResponseType(typeof(Role))]
        public async Task<IHttpActionResult> DeleteRole(int id)
        {
            Role role = await db.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            db.Role.Remove(role);
            await db.SaveChangesAsync();

            return Ok(role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleExists(int id)
        {
            return db.Role.Count(e => e.ID == id) > 0;
        }
    }
}