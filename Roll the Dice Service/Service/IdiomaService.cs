using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class IdiomaService : IService, IIdiomaService
    {
        private IUnitOfWork uow;

        public IdiomaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Idioma> GetAllIdiomas()
        {
            throw new NotImplementedException();
        }

        public Idioma GetIdiomaById(int id)
        {
            throw new NotImplementedException();
        }

        public Idioma PostIdioma(Idioma idioma)
        {
            throw new NotImplementedException();
        }

        public Idioma PutIdioma(int id, Idioma idioma)
        {
            throw new NotImplementedException();
        }

        public void DeleteIdioma(int id)
        {
            throw new NotImplementedException();
        }
    }
}