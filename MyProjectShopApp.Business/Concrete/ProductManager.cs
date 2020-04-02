using MyProjectShopApp.Business.Abstract;
using MyProjectShopApp.DataAccess.Abstract;
using MyProjectShopApp.DataAccess.Concrete.EfCore;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProjectShopApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRespository;

        public ProductManager(IProductRepository productRespository)
        {
            _productRespository = productRespository;
        }

        public void Create(Product product)
        {
            _productRespository.Create(product);
        }

        public void Delete(Product product)
        {
            _productRespository.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productRespository.GetAll().ToList();
        }

        public List<Product> GetByCategory(string category,int page, int pageSize)
        {
            return _productRespository.GetByCategory(category,page,pageSize);
        }

        public int getbycategory(string category)
        {
            return _productRespository.getbycategory(category);
        }

        public Product GetByID(int id)
        {
            return _productRespository.GetById(id);

        }

        public List<Product> GetPopularProduct()
        {
            return _productRespository.GetAll().ToList();
        }

        public Product GetProductDetails(int id)
        {
            return _productRespository.GetProductDetails(id);
        }

        public void Update(Product product)
        {
            _productRespository.Update(product);
        }
    }
}
