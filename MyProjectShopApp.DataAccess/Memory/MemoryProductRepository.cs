using MyProjectShopApp.DataAccess.Abstract;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyProjectShopApp.DataAccess.Memory
{
    public class MemoryProductRepository : IProductRepository
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> expression = null)
        {
            var products = new List<Product>()
            {
                new Product(){ID=1,ProductName="Pc",ImgURL="1.jpg",Price=1000},
                new Product(){ID=2,ProductName="Tablet",ImgURL="2.jpg",Price=2000},
                new Product(){ID=3,ProductName="Telefon",ImgURL="3.jpg",Price=3000},
                new Product(){ID=4,ProductName="Beyaz Eşya",ImgURL="4.jpg",Price=4000},



            };

            return products;
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetByCategory(string category,int page,int pageSize)
        {
            throw new NotImplementedException();
        }

        public int getbycategory(string category)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetOne(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetPopularProduct()
        {
            throw new NotImplementedException();
        }

        public Product GetProductDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
