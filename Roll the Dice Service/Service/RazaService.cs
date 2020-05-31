using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class RazaService : IService, IRazaService
    {
        private IUnitOfWork uow;

        public RazaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Raza> GetAllRazas()
        {
            throw new NotImplementedException();
        }

        public Raza GetRazaById(int id)
        {
            throw new NotImplementedException();
        }

        public Raza PostRaza(Raza raza)
        {
            throw new NotImplementedException();
        }

        public Raza PutRaza(int id, Raza raza)
        {
            throw new NotImplementedException();
        }

        public void DeleteRaza(int id)
        {
            throw new NotImplementedException();
        }
    }
}