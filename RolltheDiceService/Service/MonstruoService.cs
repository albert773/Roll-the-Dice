using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class MonstruoService : IService, IMonstruoService
    {
        private IUnitOfWork uow;

        public MonstruoService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Monstruo> GetAllMonstruos()
        {
            return uow.RepositoryClient<Monstruo>().GetAll();
        }

        public IEnumerable<Monstruo> GetAllMonstruosBySala(int id)
        {
            //TODO
            //return uow.RepositoryClient<Monstruo>().GetMany(q => q.Sala.salaId == id);
            return null;
        }

        public Monstruo GetMonstruoById(int id)
        {
            return uow.RepositoryClient<Monstruo>().GetByID(id);
        }

        public Monstruo PostMonstruo(Monstruo monstruo)
        {
            uow.RepositoryClient<Monstruo>().Insert(monstruo);
            uow.SaveChanges();
            return GetMonstruoById(monstruo.monstruoId);
        }

        public Monstruo PutMonstruo(int id, Monstruo monstruo)
        {
            uow.RepositoryClient<Monstruo>().Update(monstruo);
            uow.SaveChanges();
            return GetMonstruoById(id);
        }

        public void DeleteMonstruo(int id)
        {
            uow.RepositoryClient<Monstruo>().Delete(id);
            uow.SaveChanges();
        }
    }
}