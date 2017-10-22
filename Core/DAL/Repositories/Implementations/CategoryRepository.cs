using Core.DAL.Repositories.Interfaces;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.DAL.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private OnlineShopEntities context;

        public CategoryRepository(OnlineShopEntities context)
        {
            this.context = context;
        }

        public ItemCategory AddCategory(ItemCategory category)
        {
            return context.ItemCategories.Add(category);
        }

        public bool DeleteCategory(int categoryID)
        {
            var category = context.ItemCategories.Find(categoryID);
            if (category != null)
            {
                context.ItemCategories.Remove(category);
                return true;
            }

            return false;
        }

        public IEnumerable<ItemCategory> GetCategories()
        {
            return context.ItemCategories.ToList();
        }

        public IEnumerable<ItemCategory> GetCategoriesForCategory(int categoryID)
        {
            var category = GetCategories().FirstOrDefault(it => it.ID == categoryID);
            var categories = new List<ItemCategory>();
            categories.Add(category);
            foreach (var child in category.ItemCategories1)
            {
                categories.AddRange(GetCategoriesForCategory(child.ID));
            }

            return categories;
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

        public bool UpdateCategory(ItemCategory category)
        {
            if (context.ItemCategories.Find(category.ID) != null)
            {
                context.Entry(category).State = EntityState.Modified;
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
