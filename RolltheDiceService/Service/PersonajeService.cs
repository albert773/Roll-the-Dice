using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
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

        public IEnumerable<Personaje> GetAllPersonajesByUsuario(int id)
        {
            return uow.RepositoryClient<Personaje>().GetWithInclude(q => q.usuario == id, "Inventario.Arma",
                                                                                          "Inventario.Armadura",
                                                                                          "Inventario.Item");
        }

        public IEnumerable<Personaje> GetAllPersonajesBySala(int id)
        {
            return uow.RepositoryClient<Personaje>().GetWithInclude(q => q.Sala1.salaId == id, "Posicion1", "Raza1");
        }

        public Personaje GetPersonajeWithPosicion(int id)
        {
            return uow.RepositoryClient<Personaje>().GetWithInclude(q => q.personajeId == id, "Posicion1").FirstOrDefault();
        }

        public IEnumerable<Personaje> GetAllPersonajesByEmail(string email)
        {
            return uow.RepositoryClient<Personaje>().GetWithInclude(q => q.Usuario1.email == email, "Inventario.Arma", 
                                                                                                    "Inventario.Armadura", 
                                                                                                    "Inventario.Item");
        }

        public Personaje GetPersonajeByUsuarioAndSala(string email, int sala)
        {
            return uow.RepositoryClient<Personaje>().GetWithInclude(q => q.Usuario1.email == email && q.Sala1.salaId == sala, "Inventario.Arma", 
                                                                                                                              "Inventario.Armadura", 
                                                                                                                              "Inventario.Item").FirstOrDefault();
        }

        public Personaje GetPersonajeByUsuarioAndSala2(string email, int sala)
        {
            return uow.RepositoryClient<Personaje>().GetWithInclude(q => q.Usuario1.email == email && q.Sala1.salaId == sala, "Inventario.Arma",
                                                                                                                              "Inventario.Armadura",
                                                                                                                              "Inventario.Item",
                                                                                                                              "Habilidad",
                                                                                                                              "Posicion1",
                                                                                                                              "UnionEstatPerso",
                                                                                                                              "Usuario1",
                                                                                                                              "Raza1",
                                                                                                                              "Sala1",
                                                                                                                              "Clase1",
                                                                                                                              "Estado").FirstOrDefault();
        }

        public Personaje GetPersonajeById(int id)
        {
            return uow.RepositoryClient<Personaje>().GetWithInclude(q => q.personajeId == id, "Inventario.Arma",
                                                                                              "Inventario.Armadura",
                                                                                              "Inventario.Item", 
                                                                                              "Habilidad", 
                                                                                              "Posicion1", 
                                                                                              "UnionEstatPerso", 
                                                                                              "Usuario1",
                                                                                              "Raza1",
                                                                                              "Sala1",
                                                                                              "Clase1",
                                                                                              "Estado").FirstOrDefault();
        }

        public Personaje PostPersonaje(Personaje personaje)
        {
            uow.RepositoryClient<Personaje>().Insert(personaje);
            try
            {
                uow.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
            }
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