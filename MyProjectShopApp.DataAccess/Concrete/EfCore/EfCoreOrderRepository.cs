using Microsoft.EntityFrameworkCore;
using MyProjectShopApp.DAL.Context;
using MyProjectShopApp.DataAccess.Abstract;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyProjectShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfEntityRepository<Order, ProjectContext>, IOrderRepository
    {
        public List<Order> GetOrders(string userid)
        {
            using (var context = new ProjectContext())
            {

                var orders = context.Orders
                    .Include(i => i.orderLines)
                    .ThenInclude(i => i.Product)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(userid))
                {
                    orders.Where(i => i.UserID == userid);
                }

                return orders.ToList();
            };
        }
    }
}
