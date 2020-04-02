using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.Models.DTO
{
    public class CategoryDTO : BaseDTO
    {

        [Required(ErrorMessage ="Lütfen değerlerinizi kontrol ediniz")]
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
