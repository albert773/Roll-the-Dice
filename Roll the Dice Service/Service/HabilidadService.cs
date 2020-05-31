using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class HabilidadService : IService, IHabilidadService
    {
        private IUnitOfWork uow;

        public HabilidadService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Habilidad> GetAllHabilidades()
        {
            throw new NotImplementedException();
        }

        public Habilidad GetHabilidadById(int id)
        {
            throw new NotImplementedException();
        }

        public Habilidad PostHabilidad(Habilidad habilidad)
        {
            throw new NotImplementedException();
        }

        public Habilidad PutHabilidad(int id, Habilidad habilidad)
        {
            throw new NotImplementedException();
        }

        public void DeleteHabilidad(int id)
        {
            throw new NotImplementedException();
        }
    }
}