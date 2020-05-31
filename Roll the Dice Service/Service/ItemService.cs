using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class ItemService : IService, IItemService
    {
        private IUnitOfWork uow;

        public ItemService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAllItemsByPersonajes(int id)
        {
            throw new NotImplementedException();
        }

        public Item GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public Item GetItemByPersonaje(int id)
        {
            throw new NotImplementedException();
        }

        public Item PostItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Item PutItem(int id, Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }
    }
}