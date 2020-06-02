using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class AccionService : IService, IAccionService
    {
        private IUnitOfWork uow;

        public AccionService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public IEnumerable<Accion> GetAllAcciones()
        {
            return uow.RepositoryClient<Accion>().GetAll();
        }

        public Accion GetAccionById(int id)
        {
            return uow.RepositoryClient<Accion>().GetByID(id);
        }

        public Accion PostAccion(Accion accion)
        {
            uow.RepositoryClient<Accion>().Insert(accion);
            uow.SaveChanges();
            return GetAccionById(accion.accionId);
        }

        public Accion PutAccion(int id, Accion accion)
        {
            uow.RepositoryClient<Accion>().Update(accion);
            uow.SaveChanges();
            return GetAccionById(accion.accionId);
        }

        public void DeleteAccion(int id)
        {
            uow.RepositoryClient<Accion>().Delete(id);
            uow.SaveChanges();
        }
    }
}