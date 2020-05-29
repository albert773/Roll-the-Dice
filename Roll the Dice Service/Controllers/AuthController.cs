using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Utils;

namespace Roll_the_Dice_Service.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private static UnitOfWork uw = new UnitOfWork();
        private GenericRepository<Usuario> UsuarioDTO = uw.RepositoryClient<Usuario>();

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginRequest loginData)
        {
            if (loginData == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Usuario u = null;
            //Hacer peticion que me compruebe si existe el usuario con email X
            try
            {
                u = UsuarioDTO.GetSingle(q => q.email == loginData.Email);
            }
            catch (Exception)
            {
                return BadRequest("No existe ningun usuario con ese Email");
            }
            bool isCredentialValid = (loginData.Password == u.password);
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(loginData.Email);
                return Ok(token);
            }
            else
            {
                return BadRequest("Contraseña Incorrecta");
            }
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register(RegisterRequest registerData)
        {
            if (registerData != null) { 
                Usuario usuario = new Usuario();
                usuario.email = registerData.Email;
                usuario.nickname = registerData.Nickname;
                usuario.password = registerData.Password;
                uw.RepositoryClient<Usuario>().Insert(usuario);
                uw.SaveChanges();
                return Ok(usuario);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            
        }
    }
}