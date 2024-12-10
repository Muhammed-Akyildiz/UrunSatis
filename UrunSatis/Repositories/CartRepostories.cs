using System.Collections.Generic;
using System.Linq;
using UrunSatis.Models;

namespace UrunSatis.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly List<CartItem> _cartItems = new List<CartItem>();

        public void AddToCart(ProductModels product)
        {
            var existingItem = _cartItems.FirstOrDefault(item => item.ProductId == product.Id);
            if (existingItem == null)
            {
                _cartItems.Add(new CartItem
                {
                    ProductId = product.Id,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            else
            {
                existingItem.Quantity++;
            }
        }

        public void RemoveFromCart(int productId)
        {
            var item = _cartItems.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                _cartItems.Remove(item);
            }
        }

        public List<CartItem> GetCartItems()
        {
            return _cartItems;
        }

        public decimal GetTotal()
        {
            return _cartItems.Sum(item => item.Price * item.Quantity);
        }
    }
}
