using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
{
    [InjectableAttributeTransient]
    public class NombreArmaduraService : IService, INombreArmaduraService
    {

        private IUnitOfWork uow;

        public NombreArmaduraService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<NombreArmadura> GetAllNombreArmaduras()
        {
            return uow.RepositoryClient<NombreArmadura>().GetAll();
        }

        public NombreArmadura GetNombreArmaduraById(int id)
        {
            return uow.RepositoryClient<NombreArmadura>().GetByID(id);
        }

        public NombreArmadura PostNombreArmadura(NombreArmadura nombreArmadura)
        {
            uow.RepositoryClient<NombreArmadura>().Insert(nombreArmadura);
            uow.SaveChanges();
            return GetNombreArmaduraById(nombreArmadura.nombreArmaduraId);
        }

        public NombreArmadura PutNombreArmadura(int id, NombreArmadura nombreArmadura)
        {
            uow.RepositoryClient<NombreArmadura>().Update(nombreArmadura);
            uow.SaveChanges();
            return GetNombreArmaduraById(id);
        }

        public void DeleteNombreArmadura(int id)
        {
            uow.RepositoryClient<NombreArmadura>().Delete(id);
        }
    }
}