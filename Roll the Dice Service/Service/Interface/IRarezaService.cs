using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IRarezaService
    {
        IEnumerable<Rareza> GetAllRarezas();
        Rareza GetRarezaById(int id);
        Rareza PostRareza(Rareza rareza);
        Rareza PutRareza(int id, Rareza rareza);
        void DeleteRareza(int id);
    }
}
