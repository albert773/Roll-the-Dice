using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using System.Linq;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class HabilidadService : IService, IHabilidadService
    {
        private IUnitOfWork uow;

        public HabilidadService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Habilidad> GetAllHabilidades()
        {
            return uow.RepositoryClient<Habilidad>().GetAll();
        }

        public Habilidad GetHabilidadById(int id)
        {
            return uow.RepositoryClient<Habilidad>().GetWithInclude("Elemento1", "Estadistica1").FirstOrDefault(q => q.habilidadId == id);
        }

        public Habilidad PostHabilidad(Habilidad habilidad)
        {
            uow.RepositoryClient<Habilidad>().Insert(habilidad);
            uow.SaveChanges();
            return GetHabilidadById(habilidad.habilidadId);
        }

        public Habilidad PutHabilidad(int id, Habilidad habilidad)
        {
            uow.RepositoryClient<Habilidad>().Update(habilidad);
            uow.SaveChanges();
            return GetHabilidadById(id);
        }

        public void DeleteHabilidad(int id)
        {
            uow.RepositoryClient<Habilidad>().Delete(id);
            uow.SaveChanges();
        }
    }
}