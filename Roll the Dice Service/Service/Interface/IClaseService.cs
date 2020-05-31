using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
{
    public interface IClaseService
    {
        IEnumerable<Clase> GetAllClases();
        Clase GetClaseById(int id);
        Clase PostClase(Clase clase);
        Clase PutClase(int id, Clase clase);
        void DeleteClase(int id);
    }
}
