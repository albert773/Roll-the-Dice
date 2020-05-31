using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service
{
    public class ArmaService : IService, IArmaService
    {
        private IUnitOfWork uow;

        public ArmaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void DeleteArma(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Arma> GetAllArmas()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Arma> GetAllArmasByPersonaje(int id)
        {
            throw new NotImplementedException();
        }

        public Arma GetArmaById(int id)
        {
            throw new NotImplementedException();
        }

        public Arma PostArma(Arma arma)
        {
            throw new NotImplementedException();
        }

        public Arma PutArma(int id, Arma arma)
        {
            throw new NotImplementedException();
        }
    }
}