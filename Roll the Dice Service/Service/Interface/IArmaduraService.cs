using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IArmaduraService
    {
        IEnumerable<Armadura> GetAllArmaduras();
        Armadura GetArmaduraById(int id);
        Armadura PostArmadura(Armadura armadura);
        Armadura PutArmadura(int id, Armadura armadura);
        void DeleteArmadura(int id);
    }
}
