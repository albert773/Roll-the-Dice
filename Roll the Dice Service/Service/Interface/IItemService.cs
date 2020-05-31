using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IItemService
    {
        IEnumerable<Item> GetAllItems();
        IEnumerable<Item> GetAllItemsByPersonajes(int id);
        Item GetItemById(int id);
        Item GetItemByPersonaje(int id);
        Item PostItem(Item item);
        Item PutItem(int id, Item item);
        void DeleteItem(int id);
    }
}
