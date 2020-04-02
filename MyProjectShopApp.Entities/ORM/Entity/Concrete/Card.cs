using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Entities.ORM.Entity.Concrete
{
    public class Card
    {
        public int ID { get; set; }
        public string UserID { get; set; }

        public List<CardItems> CardItems { get; set; }
    }
}
