using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class EstadNPCService : IService, IEstadNPCService
    {
        private IUnitOfWork uow;

        public EstadNPCService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<UnionEstatNPC> GetAllEstatNPC()
        {
            return uow.RepositoryClient<UnionEstatNPC>().GetAll();
        }

        public IEnumerable<UnionEstatNPC> GetAllEstadisticasByNPC(int id)
        {
            //TODO - MtM Acabar llamada para que devuelva todas las estadisticas de un Personaje
            return uow.RepositoryClient<UnionEstatNPC>().GetAll();
        }

        public UnionEstatNPC GetEstatNPCById(int id)
        {
            return uow.RepositoryClient<UnionEstatNPC>().GetByID(id);
        }

        public UnionEstatNPC PostEstatNPC(UnionEstatNPC unionEstatNPC)
        {
            uow.RepositoryClient<UnionEstatNPC>().Insert(unionEstatNPC);
            uow.SaveChanges();
            return GetEstatNPCById(unionEstatNPC.estadisticaId);
        }

        public UnionEstatNPC PutEstatNPC(int id, UnionEstatNPC unionEstatNPC)
        {
            uow.RepositoryClient<UnionEstatNPC>().Update(unionEstatNPC);
            uow.SaveChanges();
            return GetEstatNPCById(id);
        }

        public void DeleteEstatNPC(int id)
        {
            uow.RepositoryClient<UnionEstatNPC>().Delete(id);
            uow.SaveChanges();
        }
    }
}