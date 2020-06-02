using RolltheDiceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolltheDiceService.Service.Interface
{
    public interface IEstadPersoService
    {
        IEnumerable<UnionEstatPerso> GetAllEstatPerso();
        IEnumerable<UnionEstatPerso> GetAllEstadByPersonaje(int id);
        UnionEstatPerso GetEstatPersoById(int id);
        UnionEstatPerso PostEstatPerso(UnionEstatPerso unionEstatPerso);
        UnionEstatPerso PutEstatPerso(int id, UnionEstatPerso unionEstatPerso);
        void DeleteEstatPerso(int id);
    }
}
