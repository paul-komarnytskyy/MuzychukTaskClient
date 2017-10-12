using Core.DAL.Repositories.Interfaces;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.DAL.Repositories.Implementations
{
    class ItemRepository : IItemRepository, IDisposable
    {
        private OnlineShopEntities context;

        public ItemRepository(OnlineShopEntities context)
        {
            this.context = context;
        }

        public Item AddItem(Item item)
        {
            return context.Items.Add(item);
        }

        public bool DeleteItem(int itemID)
        {
            Item item = GetItem(itemID);
            if (item != null)
            {
                context.Items.Remove(item);
                return true;
            }

            return false;
        }

        public Item GetItem(int itemID)
        {
            return context.Items.Find(itemID);
        }

        public IEnumerable<Item> GetItems()
        {
            return context.Items.ToList();
        }

        public bool Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool UpdateItem(Item item)
        {
            if (GetItem(item.ID) != null)
            {
                context.Entry(item).State = EntityState.Modified;
                return true;
            }

            return false;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
