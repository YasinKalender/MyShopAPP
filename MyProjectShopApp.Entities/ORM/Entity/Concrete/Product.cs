using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Entities.ORM.Entity.Concrete
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public string ImgURL { get; set; }

        public decimal Price { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }





    }
}
