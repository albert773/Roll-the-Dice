using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class NombreArmaduraService : IService, INombreArmaduraService
    {
        private IUnitOfWork uow;

        public NombreArmaduraService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<NombreArmadura> GetAllNombreArmaduras()
        {
            throw new NotImplementedException();
        }

        public NombreArmadura GetNombreArmaduraById(int id)
        {
            throw new NotImplementedException();
        }

        public NombreArmadura PostNombreArmadura(NombreArmadura nombreArmadura)
        {
            throw new NotImplementedException();
        }

        public NombreArmadura PutNombreArmadura(int id, NombreArmadura nombreArmadura)
        {
            throw new NotImplementedException();
        }

        public void DeleteNombreArmadura(int id)
        {
            throw new NotImplementedException();
        }
    }
}