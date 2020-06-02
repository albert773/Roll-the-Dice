using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using System.Linq;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class ElementoService : IService, IElementoService
    {
        private IUnitOfWork uow;

        public ElementoService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Elemento> GetAllElementos()
        {
            return uow.RepositoryClient<Elemento>().GetAll();
        }

        public Elemento GetElementoById(int id)
        {
            return uow.RepositoryClient<Elemento>().GetWithInclude("Arma", "Armadura", "Elemento1", "Elemento2", "Habilidad").FirstOrDefault(q => q.elementoId == id);
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
            uow.SaveChanges();
        }
    }
}