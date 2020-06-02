using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class EstadPersoService : IService, IEstadPersoService
    {
        private IUnitOfWork uow;

        public EstadPersoService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<UnionEstatPerso> GetAllEstatPerso()
        {
            return uow.RepositoryClient<UnionEstatPerso>().GetAll();
        }

        IEnumerable<UnionEstatPerso> IEstadPersoService.GetAllEstadByPersonaje(int id)
        {
            //TODO - MtM Acabar llamada para que devuelva todas las estadisticas de un Personaje
            return uow.RepositoryClient<UnionEstatPerso>().GetAll();
        }

        public UnionEstatPerso GetEstatPersoById(int id)
        {
            return uow.RepositoryClient<UnionEstatPerso>().GetByID(id);
        }

        public UnionEstatPerso PostEstatPerso(UnionEstatPerso unionEstatPerso)
        {
            uow.RepositoryClient<UnionEstatPerso>().Insert(unionEstatPerso);
            uow.SaveChanges();
            return GetEstatPersoById(unionEstatPerso.estadisticaId);
        }

        public UnionEstatPerso PutEstatPerso(int id, UnionEstatPerso unionEstatPerso)
        {
            uow.RepositoryClient<UnionEstatPerso>().Update(unionEstatPerso);
            uow.SaveChanges();
            return GetEstatPersoById(id);
        }

        public void DeleteEstatPerso(int id)
        {
            uow.RepositoryClient<UnionEstatPerso>().Delete(id);
            uow.SaveChanges();
        }
    }
}