﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrunSatis.Data;

#nullable disable

namespace UrunSatis.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UrunSatis.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Telefon",
                            Price = 15000m,
                            StockQuantity = 15
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Tablet",
                            Price = 8000m,
                            StockQuantity = 20
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "Bilgisayar",
                            Price = 25000m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "Pantolon",
                            Price = 600m,
                            StockQuantity = 80
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Name = "T-shirt",
                            Price = 300m,
                            StockQuantity = 50
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Name = "Gömlek",
                            Price = 500m,
                            StockQuantity = 70
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Name = "Mutfak Robotu",
                            Price = 2300m,
                            StockQuantity = 5
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Name = "Ütü",
                            Price = 700m,
                            StockQuantity = 15
                        });
                });

            modelBuilder.Entity("UrunSatis.Models.UrunSatis.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Elektronik"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Giyim"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ev Aletleri"
                        });
                });

            modelBuilder.Entity("UrunSatis.Models.Product", b =>
                {
                    b.HasOne("UrunSatis.Models.UrunSatis.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("UrunSatis.Models.UrunSatis.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
