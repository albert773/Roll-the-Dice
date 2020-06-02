﻿using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace RolltheDiceService.Controllers
{
    [Authorize]
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        private IUsuarioService UsuarioServ;

        public UsuariosController(IUsuarioService UsuarioServ)
        {
            this.UsuarioServ = UsuarioServ;
        }

        // GET: api/Usuarios
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllUsuarios()
        {
            IEnumerable<Usuario> usuarios = UsuarioServ.GetAllUsuarios();
            if (usuarios.Count() > 0)
            {
                return Ok(usuarios);
            }
            return BadRequest("No se ha encontrado ningun usuario");
        }

        // GET: api/Usuarios/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = UsuarioServ.GetUsuarioById(id);

            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return BadRequest("No existe ningun usuario que corresponda con ese id");
            }
        }

        // GET: api/Usuarios/ejemplo@ejemplo.com
        [HttpGet]
        [Route("{email}")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuarioByEmail(string email)
        {
            Usuario usuario = UsuarioServ.GetUsuarioByEmail(email);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
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

            try
            {
                UsuarioServ.PutUsuario(id, usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
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

            UsuarioServ.PostUsuario(usuario);

            return Ok(usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            UsuarioServ.DeleteUsuario(id);

            return Ok("Se ha eliminado correctamente");
        }
    }
}