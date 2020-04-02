using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProjectShopApp.Business.Abstract;
using MyProjectShopApp.UI.Models;

namespace MyProjectShopApp.UI.Controllers
{
    public class ShopController : Controller
    {

        private IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

       

        public IActionResult List(string category,int page=1)
        {
            const int pageSize = 3;

            return View(new ProductListModel() {
                
                pages = new Pages()
                {
                    TotalItems=_productService.getbycategory(category),
                    WhoPage=page,
                    ItemPage=pageSize,
                    ActiveCategory=category
                    


                },
                
                Products=_productService.GetByCategory(category,page, pageSize) });
        }

        public IActionResult Details(int? id)
        {

            if (id==null)
            {
                return NotFound();
            }

            var product = _productService.GetProductDetails((int)id);

            ProductDetailsModel model = new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()


            };


            return View(model);
        }
    }
}