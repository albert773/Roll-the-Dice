using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class SalaService : IService, ISalaService
    {
        private IUnitOfWork uow;

        public SalaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Sala> GetAllSalas()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sala> GetAllSalasByUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Sala GetSalaById(int id)
        {
            throw new NotImplementedException();
        }

        public Sala PostSala(Sala sala)
        {
            throw new NotImplementedException();
        }

        public Sala PutSala(int id, Sala sala)
        {
            throw new NotImplementedException();
        }
        public void DeleteSala(int id)
        {
            throw new NotImplementedException();
        }
    }
}