using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.DataAccess.Abstract
{
    public interface IOrderRepository:IRepository<Order>
    {
        List<Order> GetOrders(string userid);
    }
}
