using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.Models
{
    public class ProductDetailsModel
    {

        public Product Product { get; set; }

        public List<Category> Categories { get; set; }


    }
}
