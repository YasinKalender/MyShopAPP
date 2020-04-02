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
    public class EfCoreCategoryRepository : EfEntityRepository<Category, ProjectContext>, ICategoryRepository
    {
        public Category CategoryWithProduct(int id)
        {
            using (var context = new ProjectContext())
            {
                return context.Categories
                    .Where(i => i.ID == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault();


            }
        }

        
    }
}
