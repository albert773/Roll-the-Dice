using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IRazaService
    {
        IEnumerable<Raza> GetAllRazas();
        Raza GetRazaById(int id);
        Raza PostRaza(Raza raza);
        Raza PutRaza(int id, Raza raza);
        void DeleteRaza(int id);
    }
}
