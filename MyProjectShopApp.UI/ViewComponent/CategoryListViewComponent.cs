using Microsoft.AspNetCore.Mvc;
using MyProjectShopApp.Business.Abstract;
using MyProjectShopApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {

        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            
            
            return View(new CategoryListViewModel() {
                
                
                Categories=_categoryService.GetAll(),
                SelectedCategory=RouteData.Values["category"]?.ToString()
            
            
            });
        }
    }
}
