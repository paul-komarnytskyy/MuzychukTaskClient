
namespace Core.Model.DTO
{
    public class Item
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public Model.Item ConverToModel()
        {
            return new Model.Item
            {
                ID = ID,
                Name = Name,
                CategoryID = Category.ID,
                Price = (float)Price,
                ImageURL = ImageURL
            };

        }
    }

    public static class ItemExtensions
    {
        public static Item ConvertToDTO(this Model.Item item)
        {
            return new Item
            {
                ID = item.ID,
                Name = item.Name,
                Category = new Category
                {
                    ID = item.ItemCategory.ID,
                    Name = item.ItemCategory.Name
                },
                Price = item.Price,
                ImageURL = item.ImageURL
            };
        }
    }
}
