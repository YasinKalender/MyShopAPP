using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Entities.ORM.Entity.Concrete
{
    public class CardItems
    {
        public int ID { get; set; }


        public virtual Product Product { get; set; }
        public int ProductID { get; set; }

        public virtual Card Card { get; set; }
        public int CardID { get; set; }

        public int Quantity { get; set; }


    }
}
