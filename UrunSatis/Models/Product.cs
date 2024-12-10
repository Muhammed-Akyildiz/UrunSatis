using UrunSatis.Models.UrunSatis.Models;

namespace UrunSatis.Models
{
    public class Product
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = null!; // Product name
        public decimal Price { get; set; } // Product price
        public int StockQuantity { get; set; } // Product stock quantity

        // Foreign Key
        public int CategoryId { get; set; }
        public Category? Category { get; set; } // Relationship
    }
}