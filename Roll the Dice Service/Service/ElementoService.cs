using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using System.Linq;

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
            return uow.RepositoryClient<Elemento>().GetWithInclude("Debilidad").ToList();
        }

        public Elemento GetElementoById(int id)
        {
            return uow.RepositoryClient<Elemento>().GetWithInclude("Debilidad").Where(q => q.elementoId == id).FirstOrDefault();
        }

        public Elemento PostElemento(Elemento elemento)
        {
            uow.RepositoryClient<Elemento>().Insert(elemento);
            uow.SaveChanges();
            return GetElementoById(elemento.elementoId);
        }

        public Elemento PutElemento(int id, Elemento elemento)
        {
            uow.RepositoryClient<Elemento>().Insert(elemento);
            uow.SaveChanges();
            return GetElementoById(id);
        }
        public void DeleteElemento(int id)
        {
            uow.RepositoryClient<Elemento>().Delete(id);
        }
    }
}