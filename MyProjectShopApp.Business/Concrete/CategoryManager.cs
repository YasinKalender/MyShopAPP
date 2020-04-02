using MyProjectShopApp.Business.Abstract;
using MyProjectShopApp.DataAccess.Abstract;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category CategoryWithProduct(int id)
        {
            return _categoryRepository.CategoryWithProduct(id);
        }

        public void Create(Category category)
        {
            _categoryRepository.Create(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

      

        public List<Category> GetAll()
        {
              return  _categoryRepository.GetAll();
        }

        public Category GetByID(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
