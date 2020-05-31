using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
{
    [InjectableAttributeTransient]
    public class InventarioService : IService, IInventarioService
    {
        private IUnitOfWork uow;

        public InventarioService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Inventario> GetAllInventarios()
        {
            return uow.RepositoryClient<Inventario>().GetAll();
        }

        public Inventario GetInventarioById(int id)
        {
            return uow.RepositoryClient<Inventario>().GetByID(id);
        }

        public Inventario GetInventarioByPersonaje(int id)
        {
            return uow.RepositoryClient<Inventario>().GetFirst(q => q.Personaje.personajeId == id);
        }

        public Inventario PostInventario(Inventario inventario)
        {
            uow.RepositoryClient<Inventario>().Insert(inventario);
            uow.SaveChanges();
            return GetInventarioById(inventario.inventarioId);
        }

        public Inventario PutInventario(int id, Inventario inventario)
        {
            uow.RepositoryClient<Inventario>().Update(inventario);
            uow.SaveChanges();
            return GetInventarioById(id);
        }

        public void DeleteInventario(int id)
        {
            uow.RepositoryClient<Inventario>().Delete(id);
            uow.SaveChanges();
        }
    }
}