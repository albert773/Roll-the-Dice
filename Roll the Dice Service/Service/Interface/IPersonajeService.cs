using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    public interface IPersonajeService
    {
        IEnumerable<Personaje> GetAllPersonajes();
        IEnumerable<Personaje> GetAllPersonajesBySala(int id);
        IEnumerable<Personaje> GetAllPersonajesByUsuario(int id);
        Personaje GetPersonajeById(int id);
        Personaje PostPersonaje(Personaje personaje);
        Personaje PutPersonaje(int id, Personaje personaje);
        void DeletePersonaje(int id);
    }
}
