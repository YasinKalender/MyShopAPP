using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProjectShopApp.Business.Abstract;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using MyProjectShopApp.UI.Models.DTO;
using MyProjectShopApp.UI.Models.Order;

namespace MyProjectShopApp.UI.Controllers
{
[Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IOrderService _orderService;
       

        public AdminController(IProductService productService, ICategoryService categoryService, IOrderService orderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {


            return View(_productService.GetAll());
        }

        public IActionResult CreateProduct()
        {
            List<SelectListItem> selectListItems = _categoryService.GetAll().Select(i => new SelectListItem { Text = i.CategoryName, Value = i.ID.ToString() }).ToList();

            ViewBag.deger = selectListItems;

            return View(new ProductDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product()
                {
                    ProductName = model.ProductName,
                    ProductDescription = model.ProductDescription,
                    Price = model.Price,



                };

                if (file != null)
                {
                    entity.ImgURL = file.FileName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\IMG", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {

                        await file.CopyToAsync(stream);
                    }
                }
                List<SelectListItem> selectListItems = _categoryService.GetAll().Select(i => new SelectListItem { Text = i.CategoryName, Value = i.ID.ToString() }).ToList();

                ViewBag.deger = selectListItems;

                _productService.Create(entity);
                return RedirectToAction("Index", "Admin");
            }

            else
            {
                return View(model);
            }









        }


        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _productService.GetByID((int)id);


            ProductDTO productDTO = new ProductDTO();

            productDTO.ID = entity.ID;
            productDTO.ProductName = entity.ProductName;
            productDTO.ProductDescription = entity.ProductDescription;
            productDTO.ImgURL = entity.ImgURL;
            productDTO.Price = entity.Price;

            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductDTO product, IFormFile file)
        {
            if (ModelState.IsValid)
            {



                var products = _productService.GetByID(product.ID);

                products.ProductName = product.ProductName;
                products.ProductDescription = product.ProductDescription;
                products.Price = product.Price;
                products.status = Entities.ORM.Entity.Enum.Status.Update;
                products.UpdateDate = DateTime.Now;

                if (file != null)
                {
                    products.ImgURL = file.FileName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\IMG", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {

                        await file.CopyToAsync(stream);
                    }
                }

                _productService.Update(products);




                return RedirectToAction("Index", "Admin");

            }

            else
            {
                return View(product);
            }
        }



        public IActionResult DeleteProduct(int id)
        {
            var entity = _productService.GetByID(id);

            if (entity != null)
            {
                _productService.Delete(entity);
            }

            return RedirectToAction("ProductList", "Admin");
        }

        public IActionResult CategoryList()
        {


            return View(_categoryService.GetAll());
        }

        public IActionResult CategoryAdd()
        {


            return View();
        }


        [HttpPost]
        public IActionResult CategoryAdd(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.CategoryName = categoryDTO.CategoryName;

                _categoryService.Create(category);

                return RedirectToAction("CategoryList", "Admin");
            }

            else
            {
                return View(categoryDTO);
            }
        }



        public IActionResult CategoryUpdate(int id)
        {

            var entity = _categoryService.CategoryWithProduct(id);
            CategoryDTO categoryDTO = new CategoryDTO();

            categoryDTO.ID = entity.ID;
            categoryDTO.CategoryName = entity.CategoryName;
            categoryDTO.Products = entity.ProductCategories.Select(i => i.Product).ToList();



            return View(categoryDTO);
        }

        [HttpPost]
        public IActionResult CategoryUpdate(CategoryDTO category)
        {

            var entity = _categoryService.GetByID(category.ID);

            entity.CategoryName = category.CategoryName;
            entity.UpdateDate = DateTime.Now;
            entity.status = Entities.ORM.Entity.Enum.Status.Update;


            _categoryService.Update(entity);

            return RedirectToAction("CategoryList", "Admin");
        }

        public IActionResult CategoryDelete(int? id)
        {
            var entity = _categoryService.GetByID((int)id);

            if (entity != null)
            {
                _categoryService.Delete(entity);
            }


            return RedirectToAction("CategoryList", "Admin");
        }



        public IActionResult GetOrders()
        {
            var orders = _orderService.GetOrders(null);

            var orderslist = new List<OrderListModel>();
            OrderListModel orderListModel;

            foreach (var item in orders)
            {
                orderListModel = new OrderListModel();
                orderListModel.ID = item.ID;
                orderListModel.OrderNumber = item.OrderNumber;
                orderListModel.OrderDate = item.OrderDate;
                orderListModel.Phone = item.Phone;
                orderListModel.FirstName = item.FirstName;
                orderListModel.LastName = item.LastName;
                orderListModel.Email = item.Email;
                orderListModel.Address = item.Adress;
                orderListModel.City = item.City;

                orderListModel.OrderItemDetails = item.orderLines.Select(i => new OrderItemDetails()
                {

                    ID = i.ID,
                    Name = i.Product.ProductName,
                    Price = i.TotalPrice,
                    Quantity = i.Quantity,
                    ImageUrl = i.Product.ImgURL,





                }).ToList();

                orderslist.Add(orderListModel);

            }


            return View(orderslist);
        }



    }
}