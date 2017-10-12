using Core.Model;
using System;
using System.Collections.Generic;

namespace Core.DAL.Repositories.Interfaces
{
    public interface IItemRepository : IDisposable
    {
        IEnumerable<Item> GetItems();

        Item GetItem(int itemID);

        Item AddItem(Item item);

        bool DeleteItem(int itemID);

        bool UpdateItem(Item item);

        bool Save();
    }
}
