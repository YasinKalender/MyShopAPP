using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.Models.Card
{
    public class CardModel
    {
        public int CardID { get; set; }

        public List<CarditemModel> carditemModels { get; set; }

        public decimal Price()
        {

            return carditemModels.Sum(i => i.Price * i.Quantity);

        }

    }
}
