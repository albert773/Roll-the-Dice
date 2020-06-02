using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using System.Linq;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class ClaseService : IService, IClaseService
    {
        private IUnitOfWork uow;

        public ClaseService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Clase> GetAllClases()
        {
            return uow.RepositoryClient<Clase>().GetAll();
        }

        public Clase GetClaseById(int id)
        {
            return uow.RepositoryClient<Clase>().GetWithInclude("NPC", "Personaje").FirstOrDefault(q => q.claseId == id);
        }

        public Clase PostClase(Clase clase)
        {
            uow.RepositoryClient<Clase>().Insert(clase);
            uow.SaveChanges();
            return GetClaseById(clase.claseId);
        }

        public Clase PutClase(int id, Clase clase)
        {
            uow.RepositoryClient<Clase>().Update(clase);
            uow.SaveChanges();
            return GetClaseById(id);
        }

        public void DeleteClase(int id)
        {
            uow.RepositoryClient<Clase>().Delete(id);
            uow.SaveChanges();
        }
    }
}