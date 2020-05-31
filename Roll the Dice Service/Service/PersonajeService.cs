using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
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
            throw new NotImplementedException();
        }

        public IEnumerable<Personaje> GetAllPersonajesByUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Personaje GetPersonajeById(int id)
        {
            throw new NotImplementedException();
        }

        public Personaje PostPersonaje(Personaje personaje)
        {
            throw new NotImplementedException();
        }

        public Personaje PutPersonaje(int id, Personaje personaje)
        {
            uow.RepositoryClient<Personaje>().Update(personaje);
            uow.SaveChanges();
            return uow.RepositoryClient<Personaje>().GetSingle(q => q.personajeId == id);
        }

        public void DeletePersonaje(int id)
        {
            throw new NotImplementedException();
        }
    }
}