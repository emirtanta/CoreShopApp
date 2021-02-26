using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreShopApp.Data.Abstract
{
    public interface IOrderRepository:IRepository<Order>
    {
        List<Order> GetOrders(string userId);
    }
}
