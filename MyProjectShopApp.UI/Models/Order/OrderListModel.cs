using MyProjectShopApp.Entities.ORM.Entity.Enum;
using MyProjectShopApp.UI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.Models.Order
{
    public class OrderListModel:BaseDTO
    {


        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderState { get; set; }
        public OrderPayment PaymentTypes { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OrderNote { get; set; }

        public List<OrderItemDetails> OrderItemDetails { get; set; }

        public decimal Price()
        {

            return OrderItemDetails.Sum(i => i.Price * i.Quantity);

        }
    }
}
