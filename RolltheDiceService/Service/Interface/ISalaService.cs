using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface ISalaService
    {
        IEnumerable<Sala> GetAllSalas();
        IEnumerable<Sala> GetAllSalasByUsuario(int id);
        Sala GetSalaById(int id);
        Sala PostSala(Sala sala);
        Sala PutSala(int id, Sala sala);
        void DeleteSala(int id);
    }
}
