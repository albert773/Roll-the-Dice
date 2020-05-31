using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class InventarioService : IService, IInventarioService
    {
        private IUnitOfWork uow;

        public InventarioService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Inventario> GetAllInventarios()
        {
            throw new NotImplementedException();
        }

        public Inventario GetInventarioById(int id)
        {
            throw new NotImplementedException();
        }

        public Inventario GetInventarioByPersonaje(int id)
        {
            throw new NotImplementedException();
        }

        public Inventario PostInventario(Inventario inventario)
        {
            throw new NotImplementedException();
        }

        public Inventario PutInventario(int id, Inventario inventario)
        {
            throw new NotImplementedException();
        }

        public void DeleteInventario(int id)
        {
            throw new NotImplementedException();
        }
    }
}