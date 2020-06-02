using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

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
