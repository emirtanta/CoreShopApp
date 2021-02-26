using CoreShopApp.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreShopApp.Data.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order, ShopContext>, IOrderRepository
    {
        public List<Order> GetOrders(string userId)
        {
            using (var context=new ShopContext())
            {
                var orders = context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Product).AsQueryable();


                if (!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(x => x.UserId == userId);
                }

                return orders.ToList();

            }
        }
    }
}
