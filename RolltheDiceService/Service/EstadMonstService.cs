using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class EstadMonstService : IService, IEstadMonstService
    {
        private IUnitOfWork uow;

        public EstadMonstService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<UnionEstatMonst> GetAllEstadMonst()
        {
            return uow.RepositoryClient<UnionEstatMonst>().GetAll();
        }

        public IEnumerable<UnionEstatMonst> GetAllEstadisticasByMonstruo(int id)
        {
            //TODO - MtM Acabar llamada para que devuelva todas las estadisticas de un Personaje
            return uow.RepositoryClient<UnionEstatMonst>().GetAll();
        }

        public UnionEstatMonst GetEstadMonstById(int id)
        {
            return uow.RepositoryClient<UnionEstatMonst>().GetByID(id);
        }

        public UnionEstatMonst PostEstadMonst(UnionEstatMonst unionEstatMonst)
        {
            uow.RepositoryClient<UnionEstatMonst>().Insert(unionEstatMonst);
            uow.SaveChanges();
            return GetEstadMonstById(unionEstatMonst.estadisticaId);
        }

        public void PostAllEstadMonst(List<UnionEstatMonst> unionesEstatMonst)
        {
            foreach (var unionEstatMonst in unionesEstatMonst)
            {
                uow.RepositoryClient<UnionEstatMonst>().Insert(unionEstatMonst);
            }

            uow.SaveChanges();
        }

        public UnionEstatMonst PutEstadMonst(int id, UnionEstatMonst unionEstatMonst)
        {
            uow.RepositoryClient<UnionEstatMonst>().Update(unionEstatMonst);
            uow.SaveChanges();
            return GetEstadMonstById(id);
        }

        public void DeleteEstadMonst(int id)
        {
            uow.RepositoryClient<UnionEstatMonst>().Delete(id);
            uow.SaveChanges();
        }
    }
}