using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IEstadisticaService
    {
        IEnumerable<Estadistica> GetAllEstadisticas();
        IEnumerable<Estadistica> GetAllEstadisticasByPersonaje(int id);
        Estadistica GetEstadisticaById(int id);
        Estadistica PostEstadistica(Estadistica estadistica);
        Estadistica PutEstadistica(int id, Estadistica estadistica);
        void DeleteEstadistica(int id);
    }
}
