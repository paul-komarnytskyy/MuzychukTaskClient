using System.Collections.Generic;
using System.Linq;

namespace Core.Model.DTO
{
    public class Category : BasicCategory
    {
        public Category() : base()
        {
            this.Children = new List<BasicCategory>();
        }

        public List<BasicCategory> Children;
    }

    public static class CategoryExtentions
    {
        public static BasicCategory ConvertToDTO(this Model.ItemCategory category)
        {
            if (category.ItemCategories1.Any())
            {
                var dtoCategory = new Category();
                dtoCategory.ID = category.ID;
                dtoCategory.Name = category.Name;
                dtoCategory.ParentId = category.ParentCategoryID;
                foreach (var child in category.ItemCategories1)
                {
                    dtoCategory.Children.Add(child.ConvertToDTO());
                }

                return dtoCategory;
            }

            return new BasicCategory()
            {
                ID = category.ID,
                Name = category.Name,
                ParentId = category.ParentCategoryID
            };
        }
    }
}
