using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface INombreArmaService
    {
        IEnumerable<NombreArma> GetAllNombreArmas();
        NombreArma GetNombreArmaById(int id);
        NombreArma PostNombreArma(NombreArma nombreArma);
        NombreArma PutNombreArma(int id, NombreArma nombreArma);
        void DeleteNombreArma(int id);
    }
}
