using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

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
