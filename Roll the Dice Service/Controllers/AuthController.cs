using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Utils;
using Roll_the_Dice_Service.Service.Interface;

namespace Roll_the_Dice_Service.Controllers
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
            if (loginData == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            AuthServ.Login(loginData);
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
            if (registerData != null) {
                Usuario u = AuthServ.Register(registerData);
                return Ok(u);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            
        }
    }
}