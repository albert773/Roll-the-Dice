using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
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
            return uow.RepositoryClient<Clase>().GetByID(id);
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
        }
    }
}