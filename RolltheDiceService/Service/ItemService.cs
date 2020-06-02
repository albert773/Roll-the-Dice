using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class ItemService : IService, IItemService
    {
        private IUnitOfWork uow;

        public ItemService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return uow.RepositoryClient<Item>().GetAll();
        }

        public IEnumerable<Item> GetAllItemsByPersonaje(int id)
        {
            return null; // uow.RepositoryClient<Item>().GetWithInclude(q => q.Inventario == id, "Inventario1", "Rareza1");
        }

        public Item GetItemById(int id)
        {
            return uow.RepositoryClient<Item>().GetByID(id);
        }

        public Item PostItem(Item item)
        {
            uow.RepositoryClient<Item>().Insert(item);
            uow.SaveChanges();
            return GetItemById(item.itemId);
        }

        public Item PutItem(int id, Item item)
        {
            uow.RepositoryClient<Item>().Update(item);
            uow.SaveChanges();
            return GetItemById(id);
        }

        public void DeleteItem(int id)
        {
            uow.RepositoryClient<Item>().Delete(id);
            uow.SaveChanges();
        }
    }
}