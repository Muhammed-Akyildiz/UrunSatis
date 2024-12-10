 namespace UrunSatis.Repositories
    {
        public interface ICartRepository
        {
            void AddToCart(ProductModels product);
            void RemoveFromCart(int productId);
            List<CartItem> GetCartItems();
            decimal GetTotal();
        }
    }
