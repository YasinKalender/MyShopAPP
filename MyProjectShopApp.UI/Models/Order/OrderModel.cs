using MyProjectShopApp.UI.Models.Card;
using MyProjectShopApp.UI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.Models.Order
{
    public class OrderModel: BaseDTO
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ExpireMonth { get; set; }

        public string ExpireYear { get; set; }

        public string Cvv { get; set; }

        public string CardName { get; set; }

        public string CardNumber { get; set; }

        public CardModel CardModel { get; set; }
    }
}
