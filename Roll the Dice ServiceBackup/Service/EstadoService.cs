using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
{
    [InjectableAttributeTransient]
    public class EstadoService : IService, IEstadoService
    {
        private IUnitOfWork uow;

        public EstadoService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Estado> GetAllEstados()
        {
            return uow.RepositoryClient<Estado>().GetAll();
        }

        public Estado GetEstadoById(int id)
        {
            return uow.RepositoryClient<Estado>().GetByID(id);
        }

        public Estado PostEstado(Estado estado)
        {
            uow.RepositoryClient<Estado>().Insert(estado);
            uow.SaveChanges();
            return GetEstadoById(estado.estadoId);
        }

        public Estado PutEstado(int id, Estado estado)
        {
            uow.RepositoryClient<Estado>().Update(estado);
            uow.SaveChanges();
            return GetEstadoById(id);
        }

        public void DeleteEstado(int id)
        {
            uow.RepositoryClient<Estado>().Delete(id);
            uow.SaveChanges();
        }
    }
}