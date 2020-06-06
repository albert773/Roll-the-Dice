using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IPersonajeService
    {
        IEnumerable<Personaje> GetAllPersonajes();
        IEnumerable<Personaje> GetAllPersonajesBySala(int id);
        IEnumerable<Personaje> GetAllPersonajesByUsuario(int id);
        IEnumerable<Personaje> GetAllPersonajesByEmail(string email);
        Personaje GetPersonajeByUsuarioAndSala(string email, int sala);
        Personaje GetPersonajeWithPosicion(int id);
        Personaje GetPersonajeById(int id);
        Personaje PostPersonaje(Personaje personaje);
        Personaje PutPersonaje(int id, Personaje personaje);
        void DeletePersonaje(int id);
    }
}
