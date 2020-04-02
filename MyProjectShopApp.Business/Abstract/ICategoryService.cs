using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        Category GetByID(int id);
  

        public Category CategoryWithProduct(int id);

        void Create(Category category);

        void Update(Category category);

        void Delete(Category category);

       


    }
}
