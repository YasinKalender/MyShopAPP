using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyProjectShopApp.DataAccess.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        //Buraya Product'a ait işlemler yapılıcak

        //Örnek

        List<Product> GetPopularProduct();

        Product GetProductDetails(int id);

        List<Product> GetByCategory(string category,int page,int pageSize);
        int getbycategory(string category);
    }
}
