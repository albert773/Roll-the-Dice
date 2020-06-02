using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IEstadoService
    {
        IEnumerable<Estado> GetAllEstados();
        Estado GetEstadoById(int id);
        Estado PostEstado(Estado estado);
        Estado PutEstado(int id, Estado estado);
        void DeleteEstado(int id);
    }
}
