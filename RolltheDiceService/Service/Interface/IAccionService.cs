using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IAccionService
    {
        IEnumerable<Accion> GetAllAcciones();
        Accion GetAccionById(int id);
        Accion PostAccion(Accion accion);
        Accion PutAccion(int id, Accion accion);
        void DeleteAccion(int id);
    }
}
