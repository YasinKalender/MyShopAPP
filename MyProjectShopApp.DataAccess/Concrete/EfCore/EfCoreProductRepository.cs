using Microsoft.EntityFrameworkCore;
using MyProjectShopApp.DAL.Context;
using MyProjectShopApp.DataAccess.Abstract;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyProjectShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreProductRepository : EfEntityRepository<Product, ProjectContext>, IProductRepository
    {
        public List<Product> GetByCategory(string category,int page, int pageSize)
        {
            using (var context = new ProjectContext())
            {
                var products = context.Products.AsQueryable();


                if (!string.IsNullOrEmpty(category))
                {
                    products = products.Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(i => i.Category.CategoryName.ToLower() == category.ToLower()));
                }

                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();



            }
        }

        public int getbycategory(string category)
        {
            using (var context = new ProjectContext())
            {
                var products = context.Products.AsQueryable();


                if (!string.IsNullOrEmpty(category))
                {
                    products = products.Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(i => i.Category.CategoryName.ToLower() == category.ToLower()));
                }

                return products.Count();



            }
        }

        public List<Product> GetPopularProduct()
        {
            throw new NotImplementedException();
        }



        public Product GetProductDetails(int id)
        {

            //Eager Loading işlemi yaptık performans açısından
            using(var context = new ProjectContext())
            {
                return context.Products.Where(i => i.ID == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();


            }
        }
    }
}
