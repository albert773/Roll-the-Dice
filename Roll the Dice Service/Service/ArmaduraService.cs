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
    public class ArmaduraService : IService, IArmaduraService
    {
        private IUnitOfWork uow;

        public ArmaduraService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Armadura> GetAllArmaduras()
        {
            throw new NotImplementedException();
        }

        public Armadura GetArmaduraById(int id)
        {
            throw new NotImplementedException();
        }

        public Armadura PostArmadura(Armadura armadura)
        {
            throw new NotImplementedException();
        }

        public Armadura PutArmadura(int id, Armadura armadura)
        {
            throw new NotImplementedException();
        }

        public void DeleteArmadura(int id)
        {
            throw new NotImplementedException();
        }
    }
}