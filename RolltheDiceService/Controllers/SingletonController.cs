using RolltheDiceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RolltheDiceService.Controllers
{
    [RoutePrefix("api/singleton")]
    public class SingletonController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            object[] s = { Singleton.Accion, Singleton.Emisor, Singleton.Receptor };
            return Ok(s);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(string[] s)
        {
            Singleton.Accion = s[0];
            Singleton.Emisor = Int32.Parse(s[1]);
            Singleton.Receptor = Int32.Parse(s[2]);
            object[] s1 = { Singleton.Accion, Singleton.Emisor, Singleton.Receptor };
            return Ok(s1);
        }
    }
}