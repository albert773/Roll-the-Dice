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
    public class AccionService : IService, IAccionService
    {
        private IUnitOfWork uow;

        public AccionService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public IEnumerable<Accion> GetAllAcciones()
        {
            throw new NotImplementedException();
        }

        public Accion GetAccionById(int id)
        {
            throw new NotImplementedException();
        }

        public Accion PostAccion(Accion accion)
        {
            throw new NotImplementedException();
        }

        public Accion PutAccion(int id, Accion accion)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccion(int id)
        {
            throw new NotImplementedException();
        }
    }
}