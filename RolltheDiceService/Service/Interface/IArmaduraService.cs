using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IArmaduraService
    {
        IEnumerable<Armadura> GetAllArmaduras();
        Armadura GetArmaduraById(int id);
        IEnumerable<Armadura> GetAllArmadurasByPersonaje(int id);
        Armadura PostArmadura(Armadura armadura);
        Armadura PutArmadura(int id, Armadura armadura);
        void DeleteArmadura(int id);
        
    }
}
