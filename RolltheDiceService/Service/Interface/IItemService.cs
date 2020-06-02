﻿using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IItemService
    {
        IEnumerable<Item> GetAllItems();
        IEnumerable<Item> GetAllItemsByPersonaje(int id);
        Item GetItemById(int id);
        Item PostItem(Item item);
        Item PutItem(int id, Item item);
        void DeleteItem(int id);
    }
}
