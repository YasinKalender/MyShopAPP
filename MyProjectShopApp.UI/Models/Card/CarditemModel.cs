using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.Models.Card
{
    public class CarditemModel
    {

        public int CarditemID { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string ImgUrL { get; set; }

        public int Quantity { get; set; }
    }
}
