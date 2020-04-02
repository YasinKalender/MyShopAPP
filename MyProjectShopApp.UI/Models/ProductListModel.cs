using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProjectShopApp.UI.Models
{
    public class Pages
    {
        //Toplam Eleman
        public int TotalItems { get; set; }
        //Kac Eleman
        public int ItemPage { get; set; }

        //Hangi Sayfa
        public int WhoPage { get; set; }

        public string ActiveCategory { get; set; }

        public int TotalPage()
        {

            return (int)Math.Ceiling((decimal)(TotalItems / ItemPage));

        }

    }

    public class ProductListModel
    {
        public Pages pages { get; set; }
        public List<Product> Products { get; set; }
    }
}
