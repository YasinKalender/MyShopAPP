using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProjectShopApp.Business.Abstract;
using MyProjectShopApp.UI.Models;

namespace MyProjectShopApp.UI.Controllers
{
    public class HomeController : Controller
    {

        private IProductService _productService;
        

        public HomeController(IProductService productService)
        {
            _productService = productService;
          
        }
        public IActionResult Index()
        {
            ProductListModel model = new ProductListModel()
            {
                Products = _productService.GetAll().ToList()

            };


            return View(model);
        }
    }
}