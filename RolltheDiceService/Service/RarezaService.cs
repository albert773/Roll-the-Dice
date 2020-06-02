using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class RarezaService : IService, IRarezaService
    {
        private IUnitOfWork uow;

        public RarezaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Rareza> GetAllRarezas()
        {
            return uow.RepositoryClient<Rareza>().GetAll();
        }

        public Rareza GetRarezaById(int id)
        {
            return uow.RepositoryClient<Rareza>().GetByID(id);
        }

        public Rareza PostRareza(Rareza rareza)
        {
            uow.RepositoryClient<Rareza>().Insert(rareza);
            uow.SaveChanges();
            return GetRarezaById(rareza.rarezaId);
        }

        public Rareza PutRareza(int id, Rareza rareza)
        {
            uow.RepositoryClient<Rareza>().Update(rareza);
            uow.SaveChanges();
            return GetRarezaById(id);
        }

        public void DeleteRareza(int id)
        {
            uow.RepositoryClient<Rareza>().Delete(id);
            uow.SaveChanges();
        }
    }
}