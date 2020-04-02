using Microsoft.EntityFrameworkCore;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using MyProjectShopApp.Map.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.DAL.Context
{
    public class ProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.; Database=ShopAPP; integrated security=true");


            base.OnConfiguring(optionsBuilder);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductCategory>().HasKey(c => new { c.CategoryID, c.ProductID });
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Order> Orders { get; set; }

      

    }
}
