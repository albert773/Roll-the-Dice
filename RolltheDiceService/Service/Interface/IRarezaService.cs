using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IRarezaService
    {
        IEnumerable<Rareza> GetAllRarezas();
        Rareza GetRarezaById(int id);
        Rareza PostRareza(Rareza rareza);
        Rareza PutRareza(int id, Rareza rareza);
        void DeleteRareza(int id);
    }
}
