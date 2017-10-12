namespace Core.Model.DTO
{
    public class Category
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int ParentCategoryID { get; set; }
    }
}
