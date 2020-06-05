using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;

namespace RolltheDiceService.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private IAuthService AuthServ;

        public AuthController(IAuthService AuthServ)
        {
            this.AuthServ = AuthServ;
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginRequest loginData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            bool isCredentialValid = AuthServ.Login(loginData);
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                AuthServ.Register(registerData);
                return Ok();
            }
            catch (DbUpdateException)
            {
                return InternalServerError();
            }
        }
    }
}