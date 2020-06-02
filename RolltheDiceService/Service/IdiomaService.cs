using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class IdiomaService : IService, IIdiomaService
    {
        private IUnitOfWork uow;

        public IdiomaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Idioma> GetAllIdiomas()
        {
            return uow.RepositoryClient<Idioma>().GetAll();
        }

        public Idioma GetIdiomaById(int id)
        {
            return uow.RepositoryClient<Idioma>().GetByID(id);
        }

        public Idioma PostIdioma(Idioma idioma)
        {
            uow.RepositoryClient<Idioma>().Insert(idioma);
            uow.SaveChanges();
            return GetIdiomaById(idioma.idiomaId);
        }

        public Idioma PutIdioma(int id, Idioma idioma)
        {
            uow.RepositoryClient<Idioma>().Update(idioma);
            uow.SaveChanges();
            return GetIdiomaById(id);
        }

        public void DeleteIdioma(int id)
        {
            uow.RepositoryClient<Idioma>().Delete(id);
            uow.SaveChanges();
        }
    }
}