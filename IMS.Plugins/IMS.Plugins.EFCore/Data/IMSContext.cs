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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory() { Id = 1, Name = "Bike Seat", Quantity = 10, Price = 200 },
                new Inventory() { Id = 2, Name = "Bike Body", Quantity = 10, Price = 300 },
                new Inventory() { Id = 3, Name = "Bike Weels", Quantity = 20, Price = 100 },
                new Inventory() { Id = 4, Name = "Bike Pedels", Quantity = 20, Price = 500 }
            );
        }
    }
}
