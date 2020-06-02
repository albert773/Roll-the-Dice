using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
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
