using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IPosicionService
    {
        IEnumerable<Posicion> GetAllPosiciones();
        IEnumerable<Posicion> GetAllPosicionesBySala(int id);
        Posicion GetPosicionById(int id);
        Posicion GetPosicionByPersonaje(int id);
        Posicion PostPosicion(Posicion posicion);
        Posicion PutPosicion(int id, Posicion posicion);
        void DeletePosicion(int id);
    }
}
