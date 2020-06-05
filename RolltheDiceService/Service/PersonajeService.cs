using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using System.Linq;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class PersonajeService : IService, IPersonajeService
    {
        private IUnitOfWork uow;

        public PersonajeService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Personaje> GetAllPersonajes()
        {
            return uow.RepositoryClient<Personaje>().GetAll();
        }

        public IEnumerable<Personaje> GetAllPersonajesBySala(int id)
        {
            //TODO
            //return uow.RepositoryClient<Personaje>().GetMany(q => q.Sala.salaId == id);
            return null;
        }

        public IEnumerable<Personaje> GetAllPersonajesByUsuario(int id)
        {
            //TODO
            //return uow.RepositoryClient<Personaje>().GetMany(q => q.Usuario.usuarioId == id);
            return null;
        }

        public Personaje GetPersonajeByUsuarioAndSala(string email, string sala)
        {
            //TODO
            return uow.RepositoryClient<Personaje>().getDbSet().SqlQuery("SELECT * FROM Personaje WHERE usuario = (Select u.usuarioId from Usuario as u where u.email = '" + email + "') AND sala = (select s.salaId from Sala as s where s.nombre = '" + sala + "');").FirstOrDefault();
            //return uow.RepositoryClient<Personaje>().GetMany(q => q.Usuario.usuarioId == id);
        }

        public Personaje GetPersonajeById(int id)
        {
            return uow.RepositoryClient<Personaje>().GetByID(id);
        }

        public Personaje PostPersonaje(Personaje personaje)
        {
            uow.RepositoryClient<Personaje>().Insert(personaje);
            uow.SaveChanges();
            return GetPersonajeById(personaje.personajeId);
        }

        public Personaje PutPersonaje(int id, Personaje personaje)
        {
            uow.RepositoryClient<Personaje>().Update(personaje);
            uow.SaveChanges();
            return GetPersonajeById(id);
        }

        public void DeletePersonaje(int id)
        {
            uow.RepositoryClient<Personaje>().Delete(id);
            uow.SaveChanges();
        }
    }
}