using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Business.Abstract
{
    public interface IOrderService
    {

        void Create(Order order);

        List<Order> GetOrders(string userid);
    }
}
