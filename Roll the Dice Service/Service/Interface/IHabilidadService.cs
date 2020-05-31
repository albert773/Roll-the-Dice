using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IHabilidadService
    {
        IEnumerable<Habilidad> GetAllHabilidades();
        Habilidad GetHabilidadById(int id);
        Habilidad PostHabilidad(Habilidad habilidad);
        Habilidad PutHabilidad(int id, Habilidad habilidad);
        void DeleteHabilidad(int id);
    }
}
