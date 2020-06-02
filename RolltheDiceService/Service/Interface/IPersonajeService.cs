using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
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
