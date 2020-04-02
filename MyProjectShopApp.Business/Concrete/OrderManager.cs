using MyProjectShopApp.Business.Abstract;
using MyProjectShopApp.DataAccess.Abstract;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Business.Concrete
{
    public class OrderManager : IOrderService
    {

        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void Create(Order order)
        {
            _orderRepository.Create(order);
        }

        public List<Order> GetOrders(string userid)
        {
            return _orderRepository.GetOrders(userid);
        }
    }
}
