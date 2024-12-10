namespace UrunSatis.Models
{
    public class Cart
    {
        // Models/CartItem.cs
        public class CartItem
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }

            public Product Product { get; set; } // Product entity
        }

    }
}
