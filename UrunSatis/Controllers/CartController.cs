// Controllers/CartController.cs
using UrunSatis.Services; // CartService servisini ekliyoruz
using UrunSatis.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UrunSatis.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService; // CartService servisini alıyoruz
        private readonly IProductRepository _productRepository;

        // CartService ve IProductRepository servisini enjekte ediyoruz
        public CartController(CartService cartService, IProductRepository productRepository)
        {
            _cartService = cartService;
            _productRepository = productRepository;
        }

        // Sepeti görüntüle
        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems(); // Sepetteki ürünler
            var cartViewModel = new CartViewModel
            {
                CartItems = cartItems,
                Total = _cartService.GetTotal() // Toplam fiyat
            };
            return View(cartViewModel);
        }

        // Ürünü sepete ekle
        public IActionResult AddToCart(int productId)
        {
            var product = _productRepository.GetById(productId); // Ürünü al
            if (product != null)
            {
                _cartService.AddToCart(product); // Sepete ekle
            }
            return RedirectToAction("Index"); // Sepet sayfasına yönlendir
        }

        // Sepetten ürün çıkar
        public IActionResult RemoveFromCart(int productId)
        {
            _cartService.RemoveFromCart(productId); // Sepetten çıkar
            return RedirectToAction("Index"); // Sepet sayfasına yönlendir
        }
    }
}

