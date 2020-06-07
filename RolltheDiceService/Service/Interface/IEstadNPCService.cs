using RolltheDiceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolltheDiceService.Service.Interface
{
    public interface IEstadNPCService
    {
        IEnumerable<UnionEstatNPC> GetAllEstatNPC();
        IEnumerable<UnionEstatNPC> GetAllEstadisticasByNPC(int id);
        UnionEstatNPC GetEstatNPCById(int id);
        UnionEstatNPC PostEstatNPC(UnionEstatNPC unionEstatNPC);
        void PostAllEstatNPC(List<UnionEstatNPC> unionesEstatNPC);
        UnionEstatNPC PutEstatNPC(int id, UnionEstatNPC unionEstatNPC);
        void DeleteEstatNPC(int id);
    }
}
