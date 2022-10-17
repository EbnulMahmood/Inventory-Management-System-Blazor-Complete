using IMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore.Data
{
    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductInventory>()
                .HasKey(pi => new { pi.ProductId, pi.InventoryId });

            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductInventories)
                .HasForeignKey(pi => pi.ProductId);
            
            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Inventory)
                .WithMany(i => i.ProductInventories)
                .HasForeignKey(pi => pi.InventoryId);

            modelBuilder.Entity<Inventory>().HasData(
                new Inventory() { Id = 1, Name = "Car Engine", Quantity = 10, Price = 200 },
                new Inventory() { Id = 2, Name = "Car Body", Quantity = 10, Price = 300 },
                new Inventory() { Id = 3, Name = "Car Weels", Quantity = 20, Price = 100 },
                new Inventory() { Id = 4, Name = "Car Pedels", Quantity = 20, Price = 500 },
                new Inventory() { Id = 5, Name = "Electric Engine", Quantity = 10, Price = 200 },
                new Inventory() { Id = 6, Name = "Car Battery", Quantity = 10, Price = 200 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Electric Car", Quantity = 15, Price = 200000 },
                new Product() { Id = 2, Name = "Gas Car", Quantity = 20, Price = 300000 },
                new Product() { Id = 3, Name = "Product 3", Quantity = 30, Price = 1090 },
                new Product() { Id = 4, Name = "Product 4", Quantity = 40, Price = 4500 },
                new Product() { Id = 5, Name = "Product 5", Quantity = 25, Price = 4000 }
            );

            modelBuilder.Entity<ProductInventory>().HasData(
                new ProductInventory() { ProductId = 1, InventoryId = 1, InventoryQuantity = 1},
                new ProductInventory() { ProductId = 1, InventoryId = 2, InventoryQuantity = 1},
                new ProductInventory() { ProductId = 1, InventoryId = 3, InventoryQuantity = 4},
                new ProductInventory() { ProductId = 1, InventoryId = 4, InventoryQuantity = 5}
            );

            modelBuilder.Entity<ProductInventory>().HasData(
                new ProductInventory() { ProductId = 2, InventoryId = 5, InventoryQuantity = 1 },
                new ProductInventory() { ProductId = 2, InventoryId = 2, InventoryQuantity = 1 },
                new ProductInventory() { ProductId = 2, InventoryId = 3, InventoryQuantity = 4 },
                new ProductInventory() { ProductId = 2, InventoryId = 4, InventoryQuantity = 4 },
                new ProductInventory() { ProductId = 2, InventoryId = 6, InventoryQuantity = 1 }
            );
        }
    }
}
