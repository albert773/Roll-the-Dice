using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IEstadisticaService
    {
        IEnumerable<Estadistica> GetAllEstadisticas();
        IEnumerable<Estadistica> GetAllEstadisticasByPersonaje(int id);
        Estadistica GetEstadisticaById(int id);
        Estadistica PostEstadistica(Estadistica accion);
        Estadistica PutEstadistica(int id, Estadistica accion);
        void DeleteEstadistica(int id);
    }
}
