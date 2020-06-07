using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class SalaService : IService, ISalaService
    {
        private IUnitOfWork uow;

        public SalaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Sala> GetAllSalas()
        {
            return uow.RepositoryClient<Sala>().GetAll();
        }

        public IEnumerable<Sala> GetAllSalasByUsuario(int id)
        {
            return uow.RepositoryClient<Sala>().GetMany(q => q.Usuario.usuarioId == id);
        }

        public Sala GetSalaByNombre(string nombre)
        {
            return uow.RepositoryClient<Sala>().GetWithInclude(q => q.nombre == nombre, "Mapa",
                                                                                        "Monstruo",
                                                                                        "NPC",
                                                                                        "Personaje",
                                                                                        "Usuario").FirstOrDefault();
        }

        public Sala GetSalaById(int id)
        {
            return uow.RepositoryClient<Sala>().GetWithInclude(q => q.salaId == id, "Mapa",
                                                                                    "Monstruo",
                                                                                    "NPC",
                                                                                    "Personaje",
                                                                                    "Usuario").FirstOrDefault();
        }

        public Sala PostSala(Sala sala)
        {
            uow.RepositoryClient<Sala>().Insert(sala);
            uow.SaveChanges();
            return GetSalaById(sala.salaId);
        }

        public Sala PutSala(int id, Sala sala)
        {
            uow.RepositoryClient<Sala>().Update(sala);
            uow.SaveChanges();
            return GetSalaById(id);
        }
        public void DeleteSala(int id)
        {
            uow.RepositoryClient<Sala>().Delete(id);
            uow.SaveChanges();
        }
    }
}