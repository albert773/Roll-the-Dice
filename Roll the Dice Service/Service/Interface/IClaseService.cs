using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IClaseService
    {
        IEnumerable<Clase> GetAllClases();
        Clase GetClaseById(int id);
        Clase PostClase(Clase clase);
        Clase PutClase(int id, Clase clase);
        void DeleteClase(int id);
    }
}
