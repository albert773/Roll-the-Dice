using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class MapaService : IService, IMapaService
    {
        private IUnitOfWork uow;

        public MapaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Mapa> GetAllMapas()
        {
            return uow.RepositoryClient<Mapa>().GetAll();
        }

        public Mapa GetMapaById(int id)
        {
            return uow.RepositoryClient<Mapa>().GetByID(id);
        }

        public Mapa GetMapaBySala(int id)
        {
            //TODO
            //return uow.RepositoryClient<Mapa>().GetSingle(q => q.Sala.salaId == id);
            return null;
        }

        public Mapa PostMapa(Mapa mapa)
        {
            uow.RepositoryClient<Mapa>().Insert(mapa);
            uow.SaveChanges();
            return GetMapaById(mapa.mapaId);
        }

        public Mapa PutMapa(int id, Mapa mapa)
        {
            uow.RepositoryClient<Mapa>().Update(mapa);
            uow.SaveChanges();
            return GetMapaById(id);
        }

        public void DeleteMapa(int id)
        {
            uow.RepositoryClient<Mapa>().Delete(id);
            uow.SaveChanges();
        }
    }
}