namespace UrunSatis.Models
{
    namespace UrunSatis.Models
    {
        public class Category
        {
            public int Id { get; set; } // Primary Key
            public string Name { get; set; } = null!; // Category name

            // Relationship
            public ICollection<Product>? Products { get; set; } // Products in this category
        }
    }
}
