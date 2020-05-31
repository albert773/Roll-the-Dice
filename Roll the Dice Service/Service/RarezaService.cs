using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class RarezaService : IService, IRarezaService
    {
        private IUnitOfWork uow;

        public RarezaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Rareza> GetAllRarezas()
        {
            throw new NotImplementedException();
        }

        public Rareza GetRarezaById(int id)
        {
            throw new NotImplementedException();
        }

        public Rareza PostRareza(Rareza rareza)
        {
            throw new NotImplementedException();
        }

        public Rareza PutRareza(int id, Rareza rareza)
        {
            throw new NotImplementedException();
        }

        public void DeleteRareza(int id)
        {
            throw new NotImplementedException();
        }
    }
}