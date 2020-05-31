using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IPosicionService
    {
        IEnumerable<Posicion> GetAllPosiciones();
        IEnumerable<Posicion> GetAllPosicionesByMapa(int id);
        Posicion GetPosicionById(int id);
        Posicion GetPosicionByPersonaje(int id);
        Posicion PostPosicion(Posicion posicion);
        Posicion PutPosicion(int id, Posicion posicion);
        void DeletePosicion(int id);
    }
}
