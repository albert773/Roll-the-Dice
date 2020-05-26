using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Roll_the_Dice_Service.Controllers
{
    [Authorize]
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            var usuarioFake = "usuario-fake";
            return Ok(usuarioFake);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var usuariosFake = new string[] { "usuario-1", "usuario-2", "usuario-3" };
            return Ok(usuariosFake);
        }
    }
}
