using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.DataAccess.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {

        public Category CategoryWithProduct(int id);

       
    }
}
