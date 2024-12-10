using Microsoft.AspNetCore.Mvc;
using UrunSatis.Data;
using UrunSatis.Models;
using System.Linq;

namespace UrunSatis.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listeleme (Index)
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products); // Views/Product/Index.cshtml
        }

        // Yeni Ürün Ekleme (GET: Create)
        public IActionResult Create()
        {
            return View(); // Views/Product/Create.cshtml
        }

        // Yeni Ürün Ekleme (POST: Create)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Ürün Düzenleme (GET: Edit)
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product); // Views/Product/Edit.cshtml
        }

        // Ürün Düzenleme (POST: Edit)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Ürün Silme (GET: Delete)
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product); // Views/Product/Delete.cshtml
        }

        // Ürün Silme (POST: Delete)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

