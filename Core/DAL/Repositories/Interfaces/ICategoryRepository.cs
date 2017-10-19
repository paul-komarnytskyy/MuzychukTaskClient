using Core.Model;
using System;
using System.Collections.Generic;

namespace Core.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<ItemCategory> GetCategories();

        ItemCategory AddCategory(ItemCategory category);

        bool DeleteCategory(int categoryID);

        bool UpdateCategory(ItemCategory category);

        IEnumerable<ItemCategory> GetCategoriesForCategory(int categoryID);

        bool Save();
    }
}