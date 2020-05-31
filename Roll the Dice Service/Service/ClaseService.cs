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
    public class ClaseService : IService, IClaseService
    {
        private IUnitOfWork uow;

        public ClaseService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Clase> GetAllClases()
        {
            throw new NotImplementedException();
        }

        public Clase GetClaseById(int id)
        {
            throw new NotImplementedException();
        }

        public Clase PostClase(Clase clase)
        {
            throw new NotImplementedException();
        }

        public Clase PutClase(int id, Clase clase)
        {
            throw new NotImplementedException();
        }

        public void DeleteClase(int id)
        {
            throw new NotImplementedException();
        }
    }
}