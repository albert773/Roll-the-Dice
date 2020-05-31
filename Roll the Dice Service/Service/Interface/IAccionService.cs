using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IAccionService
    {
        IEnumerable<Accion> GetAllAcciones();
        Accion GetAccionById(int id);
        Accion PostAccion(Accion accion);
        Accion PutAccion(int id, Accion accion);
        void DeleteAccion(int id);
    }
}
