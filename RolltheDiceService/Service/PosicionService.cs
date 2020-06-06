using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class PosicionService : IService, IPosicionService
    {
        private IUnitOfWork uow;

        public PosicionService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Posicion> GetAllPosiciones()
        {
            return uow.RepositoryClient<Posicion>().GetAll();
        }

        public IEnumerable<Posicion> GetAllPosicionesBySala(int id)
        {
            return uow.RepositoryClient<Posicion>().GetWithInclude(q => q.Mapa1.Sala1.salaId == id, "Personaje", "Monstruo", "NPC");
        }

        public Posicion GetPosicionById(int id)
        {
            return uow.RepositoryClient<Posicion>().GetWithInclude(q => q.posicionId == id, "Personaje", "Monstruo", "NPC").FirstOrDefault();
        }

        public Posicion GetPosicionByPersonaje(int id)
        {
            return uow.RepositoryClient<Posicion>().GetWithInclude(q => q.Personaje.Any(x => x.personajeId == id), "Personaje", "Monstruo", "NPC").FirstOrDefault();
        }

        public Posicion PostPosicion(Posicion posicion)
        {
            uow.RepositoryClient<Posicion>().Insert(posicion);
            uow.SaveChanges();
            return GetPosicionById(posicion.posicionId);
        }

        public Posicion PutPosicion(int id, Posicion posicion)
        {
            uow.RepositoryClient<Posicion>().Update(posicion);
            uow.SaveChanges();
            return GetPosicionById(id);
        }

        public void DeletePosicion(int id)
        {
            uow.RepositoryClient<Posicion>().Delete(id);
            uow.SaveChanges();
        }
    }
}