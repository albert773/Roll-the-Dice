using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
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
