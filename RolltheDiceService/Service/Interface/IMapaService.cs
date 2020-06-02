using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IMapaService
    {
        IEnumerable<Mapa> GetAllMapas();
        Mapa GetMapaById(int id);
        Mapa GetMapaBySala(int id);
        Mapa PostMapa(Mapa mapa);
        Mapa PutMapa(int id, Mapa mapa);
        void DeleteMapa(int id);
    }
}
