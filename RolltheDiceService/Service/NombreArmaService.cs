using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class NombreArmaService : IService, INombreArmaService
    {

        private IUnitOfWork uow;

        public NombreArmaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<NombreArma> GetAllNombreArmas()
        {
            return uow.RepositoryClient<NombreArma>().GetAll();
        }

        public NombreArma GetNombreArmaById(int id)
        {
            return uow.RepositoryClient<NombreArma>().GetByID(id);
        }

        public NombreArma PostNombreArma(NombreArma NombreArma)
        {
            uow.RepositoryClient<NombreArma>().Insert(NombreArma);
            uow.SaveChanges();
            return GetNombreArmaById(NombreArma.nombreArmaId);
        }

        public NombreArma PutNombreArma(int id, NombreArma NombreArma)
        {
            uow.RepositoryClient<NombreArma>().Update(NombreArma);
            uow.SaveChanges();
            return GetNombreArmaById(id);
        }

        public void DeleteNombreArma(int id)
        {
            uow.RepositoryClient<NombreArma>().Delete(id);
            uow.SaveChanges();
        }
    }
}