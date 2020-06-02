using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IHabilidadService
    {
        IEnumerable<Habilidad> GetAllHabilidades();
        Habilidad GetHabilidadById(int id);
        Habilidad PostHabilidad(Habilidad habilidad);
        Habilidad PutHabilidad(int id, Habilidad habilidad);
        void DeleteHabilidad(int id);
    }
}
