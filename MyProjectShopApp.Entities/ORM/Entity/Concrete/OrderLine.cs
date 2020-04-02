using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Entities.ORM.Entity.Concrete
{
    public class OrderLine:BaseEntity
    {

        public int OrderID { get; set; }

        public virtual Order Order { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }
    }
}
