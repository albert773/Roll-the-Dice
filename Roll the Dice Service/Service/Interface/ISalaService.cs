using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface ISalaService
    {
        IEnumerable<Sala> GetAllSalas();
        IEnumerable<Sala> GetAllSalasByUsuario(int id);
        Sala GetSalaById(int id);
        Sala PostSala(Sala sala);
        Sala PutSala(int id, Sala sala);
        void DeleteSala(int id);
    }
}
