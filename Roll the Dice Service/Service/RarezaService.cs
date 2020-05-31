using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
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
        }
    }
}