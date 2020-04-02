using Microsoft.AspNetCore.Mvc.Rendering;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.Models.DTO
{
    public class ProductDTO : BaseDTO
    {
        [Required(ErrorMessage = "Lütfen değerlerini kontrol ediniz")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Lütfen değerlerini kontrol ediniz")]
        public string ProductDescription { get; set; }

        public string ImgURL { get; set; }
        [Required(ErrorMessage = "Lütfen değerlerini kontrol ediniz"), Range(1, 1000000000)]
        public decimal Price { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }








    }
}
