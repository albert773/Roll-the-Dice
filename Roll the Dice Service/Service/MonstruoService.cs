using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class MonstruoService : IService, IMonstruoService
    {
        private IUnitOfWork uow;

        public MonstruoService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Monstruo> GetAllMonstruos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Monstruo> GetAllMonstruosBySala(int id)
        {
            throw new NotImplementedException();
        }

        public Monstruo GetMonstruoById(int id)
        {
            throw new NotImplementedException();
        }

        public Monstruo PostMonstruo(Monstruo monstruo)
        {
            throw new NotImplementedException();
        }

        public Monstruo PutMonstruo(int id, Monstruo monstruo)
        {
            throw new NotImplementedException();
        }

        public void DeleteMonstruo(int id)
        {
            throw new NotImplementedException();
        }
    }
}