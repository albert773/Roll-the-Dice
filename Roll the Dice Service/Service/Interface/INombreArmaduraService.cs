using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface INombreArmaduraService
    {
        IEnumerable<NombreArmadura> GetAllNombreArmaduras();
        NombreArmadura GetNombreArmaduraById(int id);
        NombreArmadura PostNombreArmadura(NombreArmadura nombreArmadura);
        NombreArmadura PutNombreArmadura(int id, NombreArmadura nombreArmadura);
        void DeleteNombreArmadura(int id);
    }
}
