using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IMapaService
    {
        IEnumerable<Mapa> GetAllMapas();
        Mapa GetMapaById(int id);
        Mapa GetMapaBySala(int id);
        Mapa PostMapa(Mapa mapa);
        Mapa PutMapa(int id, Mapa mapa);
        void DeleteMapa(int id);
    }
}
