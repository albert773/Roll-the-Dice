using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class EstadoService : IService, IEstadoService
    {
        private IUnitOfWork uow;

        public EstadoService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Estado> GetAllEstados()
        {
            throw new NotImplementedException();
        }

        public Estado GetEstadoById(int id)
        {
            throw new NotImplementedException();
        }

        public Estado PostEstado(Estado estado)
        {
            throw new NotImplementedException();
        }

        public Estado PutEstado(int id, Estado estado)
        {
            throw new NotImplementedException();
        }

        public void DeleteEstado(int id)
        {
            throw new NotImplementedException();
        }
    }
}