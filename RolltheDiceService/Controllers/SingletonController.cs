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
            object[] s = { Singleton.Accion, Singleton.Elemento, Singleton.Emisor, Singleton.Receptor };
            return Ok(s);
        }

        [HttpGet]
        [Route("dados")]
        public IHttpActionResult GetDados()
        {
            return Ok(Singleton.Dado);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(string[] s)
        {
            Singleton.Accion = s[0];
            Singleton.Elemento = Int32.Parse(s[1]);
            Singleton.Emisor = Int32.Parse(s[2]);
            Singleton.Receptor = Int32.Parse(s[3]);
            object[] s1 = { Singleton.Accion, Singleton.Elemento, Singleton.Emisor, Singleton.Receptor };
            return Ok(s1);
        }

        [HttpPost]
        [Route("dados")]
        public IHttpActionResult PostDados(int[] d)
        {
            Singleton.Dado = d[0];
            return Ok();
        }

        [HttpGet]
        [Route("orden")]
        public IHttpActionResult GetOrden()
        {
            object[] s = { Singleton.OrdenTurnos };
            return Ok(s);
        }

        [HttpPost]
        [Route("orden")]
        public IHttpActionResult PostOrden(int[] o)
        {
            Singleton.OrdenTurnos = new List<int>();
            foreach (var user in o)
            {
                Singleton.OrdenTurnos.Add(user);
            }
            return Ok();
        }

        [HttpGet]
        [Route("turnoActual")]
        public IHttpActionResult GetTurnoActual()
        {
            return Ok(Singleton.TurnoActual);
        }

        [HttpPost]
        [Route("turnoActual")]
        public IHttpActionResult PostTurnoActual(int t)
        {
            Singleton.TurnoActual = t;
            return Ok();
        }

        [HttpGet]
        [Route("isMyTurn/{usuarioId}")]
        public IHttpActionResult GetIsMyTurn(int usuarioId)
        {
            if (Singleton.OrdenTurnos == null) return Ok(false);
            if (usuarioId == null || usuarioId == 0) return Ok(false);
            if (Singleton.OrdenTurnos.Contains(usuarioId))
            {
                return Ok(Singleton.isMyTurn(usuarioId));
            }  

            return Ok();
        }
    }
}