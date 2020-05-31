using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
{
    public interface INombreArmaduraService
    {
        IEnumerable<NombreArmadura> GetAllNombreArmaduras();
        NombreArmadura GetNombreArmaduraById(int id);
        NombreArmadura PostNombreArmadura(NombreArmadura nombreArmadura);
        NombreArmadura PutNombreArmadura(int id, NombreArmadura nombreArmadura);
        void DeleteNombreArmadura(int id);
    }
}
