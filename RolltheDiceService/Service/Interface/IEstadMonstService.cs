using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IEstadMonstService
    {
        IEnumerable<UnionEstatMonst> GetAllEstadMonst();
        IEnumerable<UnionEstatMonst> GetAllEstadisticasByMonstruo(int id);
        UnionEstatMonst GetEstadMonstById(int id);
        UnionEstatMonst PostEstadMonst(UnionEstatMonst unionEstatMonst);
        UnionEstatMonst PutEstadMonst(int id, UnionEstatMonst unionEstatMonst);
        void DeleteEstadMonst(int id);
    }
}