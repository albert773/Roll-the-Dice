using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
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
            return uow.RepositoryClient<Mapa>().GetSingle(q => q.Sala.salaId == id);
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