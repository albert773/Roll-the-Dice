using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

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
