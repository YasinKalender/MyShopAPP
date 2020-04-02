using Microsoft.EntityFrameworkCore;
using MyProjectShopApp.DAL.Context;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProjectShopApp.DAL.SeedDatabase
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ProjectContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {

                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(productCategories);
                }

                context.SaveChanges();



            }


        }

        private static Category[] Categories =
        {
            new Category(){CategoryName="Telefon"},
            new Category(){CategoryName="Elektronik"},
            new Category(){CategoryName="Tablet"}



        };

        private static Product[] Products =
       {

            new Product(){ProductName="Samsung s5",ProductDescription="Samsung Galaxy S5 mini 16GB Cep Telefonu Teşhir Ürünü",Price=1000,ImgURL="1.jpg"},
            new Product(){ProductName="Samsung s6",ProductDescription="Samsung Galaxy S6 32GB Cep Telefonu",Price=2000,ImgURL="2.jpg"},
            new Product(){ProductName="İPhone 7",ProductDescription="iPhone 7; suya dayanıklı tasarım,* uzun süren pil ömrü,** harika performans ve  Touch ID özelliklerine sahip",Price=3000,ImgURL="3.jpg"},
            new Product(){ProductName="İPhone 8",ProductDescription="iPhone 7; suya dayanıklı tasarım,* uzun süren pil ömrü,** harika performans ve  Touch ID özelliklerine sahip",Price=4000,ImgURL="4.jpg"},



        };

        private static ProductCategory[] productCategories =
        {
            new ProductCategory(){Product=Products[0],Category=Categories[0]},
            new ProductCategory(){Product=Products[0],Category=Categories[1]},
            new ProductCategory(){Product=Products[1],Category=Categories[0]},
             new ProductCategory(){Product=Products[2],Category=Categories[0]},
             new ProductCategory(){Product=Products[2],Category=Categories[1]},
             new ProductCategory(){Product=Products[3],Category=Categories[0]},


        };




    }
}
