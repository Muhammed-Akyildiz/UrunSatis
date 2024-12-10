using System.Collections.Generic;
using System.Linq;
using UrunSatis.Models;

namespace UrunSatis.Services
{
    public class CartService
    {
        private readonly List<CartItem> _cartItems = new List<CartItem>();

        // Sepete ürün eklemek
        public void AddToCart(Product product)
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

        // Sepetten ürün çıkarmak
        public void RemoveFromCart(int productId)
        {
            var item = _cartItems.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                _cartItems.Remove(item);
            }
        }

        // Sepetteki ürünleri almak
        public List<CartItem> GetCartItems() => _cartItems;

        // Toplam fiyatı hesaplamak
        public decimal GetTotal() => _cartItems.Sum(item => item.Price * item.Quantity);
    }
}
