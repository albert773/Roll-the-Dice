using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IEstadisticaService
    {
        IEnumerable<Estadistica> GetAllEstadisticas();
        IEnumerable<Estadistica> GetAllEstadisticasByPersonaje(int id);
        Estadistica GetEstadisticaById(int id);
        Estadistica PostEstadistica(Estadistica estadistica);
        Estadistica PutEstadistica(int id, Estadistica estadistica);
        void DeleteEstadistica(int id);
    }
}
