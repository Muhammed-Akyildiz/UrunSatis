using Microsoft.EntityFrameworkCore;
using UrunSatis.Models;
using UrunSatis.Models.UrunSatis.Models;

namespace UrunSatis.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // Seed Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Kategoriler
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Elektronik" },
                new Category { Id = 2, Name = "Giyim" },
                new Category { Id = 3, Name = "Ev Aletleri" }
            );

            // Ürünler
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Telefon", Price = 15000, StockQuantity = 15, CategoryId = 1 },
                new Product { Id = 2, Name = "Tablet", Price = 8000, StockQuantity = 20, CategoryId = 1 },
                new Product { Id = 3, Name = "Bilgisayar", Price = 25000, StockQuantity = 10, CategoryId = 1 },
                new Product { Id = 4, Name = "Pantolon", Price = 600, StockQuantity = 80, CategoryId = 2 },
                new Product { Id = 5, Name = "T-shirt", Price = 300, StockQuantity = 50, CategoryId = 2 },
                new Product { Id = 6, Name = "Gömlek", Price = 500, StockQuantity =70, CategoryId = 2 },
                new Product { Id = 7, Name = "Mutfak Robotu", Price = 2300, StockQuantity = 5, CategoryId = 3 },
                new Product { Id = 8, Name = "Ütü", Price = 700, StockQuantity = 15, CategoryId = 3 }
            );

            // Price sütununa precision ve scale belirleme
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)"); // decimal(18,2) ile 18 basamağa kadar sayı ve 2 ondalıklı basamak belirtiliyor
        }
    }
}
