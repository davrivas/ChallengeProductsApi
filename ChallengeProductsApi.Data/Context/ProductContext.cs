using ChallengeProductsApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeProductsApi.Data.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description);
                entity.Property(e => e.Price);
                entity.Property(e => e.SoldDate);
                entity.Property(e => e.IsActive);
                entity.Property(e => e.ProductTypeId);

                entity.HasOne(e => e.ProductType)
                    .WithMany(e => e.Products)
                    .HasForeignKey(e => e.ProductTypeId);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductType");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name);
            });
        }
    }
}
