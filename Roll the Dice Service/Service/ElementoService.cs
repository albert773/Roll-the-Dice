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
    public class ElementoService : IService, IElementoService
    {
        private IUnitOfWork uow;

        public ElementoService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Elemento> GetAllElementos()
        {
            throw new NotImplementedException();
        }

        public Elemento GetElementoById(int id)
        {
            return uow.RepositoryClient<Elemento>().GetWithInclude("Debilidad").Where(q => q.elementoId == id).FirstOrDefault();
        }

        public Elemento PostElemento(Elemento elemento)
        {
            throw new NotImplementedException();
        }

        public Elemento PutElemento(int id, Elemento elemento)
        {
            throw new NotImplementedException();
        }
        public void DeleteElemento(int id)
        {
            throw new NotImplementedException();
        }
    }
}