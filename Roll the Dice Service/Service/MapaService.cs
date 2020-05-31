using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class MapaService : IService, IMapaService
    {
        private IUnitOfWork uow;

        public MapaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Mapa> GetAllMapas()
        {
            throw new NotImplementedException();
        }

        public Mapa GetMapaById(int id)
        {
            throw new NotImplementedException();
        }

        public Mapa GetMapaBySala(int id)
        {
            throw new NotImplementedException();
        }

        public Mapa PostMapa(Mapa mapa)
        {
            throw new NotImplementedException();
        }

        public Mapa PutMapa(int id, Mapa mapa)
        {
            throw new NotImplementedException();
        }

        public void DeleteMapa(int id)
        {
            throw new NotImplementedException();
        }
    }
}