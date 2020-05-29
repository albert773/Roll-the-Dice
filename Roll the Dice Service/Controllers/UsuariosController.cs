using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Utils;

namespace Roll_the_Dice_Service.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Usuario> UsuarioDTO = uw.RepositoryClient<Usuario>();

        // GET: api/Usuarios
        [HttpGet]
        [Route("")]
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            IEnumerable<Usuario> usuarios = UsuarioDTO.GetAll();
            if (usuarios.Count() > 0)
            {
                return usuarios.ToList();
            }
            return usuarios;
        }

        // GET: api/Usuarios/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = UsuarioDTO.GetByID(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // GET: api/Usuarios/ejemplo@ejemplo.com
        [HttpGet]
        [Route("{email}")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuarioByEmail(string email)
        {
            if (email == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Usuario u = null;
            try
            {
                u = UsuarioDTO.GetFirst(q => q.email == email);
                return Ok(u);
            }
            catch (Exception)
            {
                return BadRequest("No existe ningun usuario con ese Email");
            }
        }

        // PUT: api/Usuarios/5
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.usuarioId)
            {
                return BadRequest();
            }

            UsuarioDTO.Update(usuario);

            try
            {
                uw.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("El usuario se ha modificado correctamente");
        }

        // POST: api/Usuarios
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UsuarioDTO.Insert(usuario);
            uw.SaveChanges();

            return Ok();
        }

        // DELETE: api/Usuarios/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = UsuarioDTO.GetByID(id);
            if (usuario == null)
            {
                return NotFound();
            }

            UsuarioDTO.Delete(usuario);
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

        private bool UsuarioExists(int id)
        {
            return UsuarioDTO.getDbSet().Count(e => e.usuarioId == id) > 0;
        }
    }
}