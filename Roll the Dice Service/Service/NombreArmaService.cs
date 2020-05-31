using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class NombreArmaService : IService, INombreArmaService
    {
        private IUnitOfWork uow;

        public NombreArmaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<NombreArma> GetAllNombreArmas()
        {
            throw new NotImplementedException();
        }

        public NombreArma GetNombreArmaById(int id)
        {
            throw new NotImplementedException();
        }

        public NombreArma PostNombreArma(NombreArma nombreArma)
        {
            throw new NotImplementedException();
        }

        public NombreArma PutNombreArma(int id, NombreArma nombreArma)
        {
            throw new NotImplementedException();
        }

        public void DeleteNombreArma(int id)
        {
            throw new NotImplementedException();
        }
    }
}