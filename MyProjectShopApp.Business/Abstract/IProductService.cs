using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Business.Abstract
{
    public interface IProductService
    {

        List<Product> GetAll();

        List<Product> GetPopularProduct();

        Product GetByID(int id);

        void Create(Product product);

        void Delete(Product product);

        void Update(Product product);

        Product GetProductDetails(int id);

        List<Product> GetByCategory(string category,int page, int pageSize);
        int getbycategory(string category);
    }
}
