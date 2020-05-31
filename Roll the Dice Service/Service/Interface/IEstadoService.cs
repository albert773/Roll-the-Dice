using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IEstadoService
    {
        IEnumerable<Estado> GetAllEstados();
        Estado GetEstadoById(int id);
        Estado PostEstado(Estado estado);
        Estado PutEstado(int id, Estado estado);
        void DeleteEstado(int id);
    }
}
