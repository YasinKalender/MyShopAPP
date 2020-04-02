using MyProjectShopApp.UI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.Models.Order
{
    public class OrderItemDetails:BaseDTO
    {

      
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
