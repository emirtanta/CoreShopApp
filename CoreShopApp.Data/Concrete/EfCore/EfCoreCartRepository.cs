
using CoreShopApp.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreShopApp.Data.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<EfCoreCartRepository, ShopContext>, ICartRepository
    {
        public void ClearCart(string cartId)
        {
            using (var context = new ShopContext())
            {
                var cmd = @"delete from CartItems where CartId=@p0";

                context.Database.ExecuteSqlRaw(cmd, cartId, cartId);
            }
        }

        public void Create(Cart entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Cart entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromCart(int cartId, int productId)
        {
            using (var context = new ShopContext())
            {
                var cmd = @"delete from CartItem where CartId=@p0 and ProductId=@p1";

                context.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }

        public Cart GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Cart GetByUserId(string userId)
        {
            using (var context = new ShopContext())
            {
                return context.Carts
                 .Include(i => i.CartItems)
                 .ThenInclude(i => i.Product)
                 .FirstOrDefault(i => i.UserId == userId);
            }
        }

        public void Update(Cart entity)
        {
            using (var context = new ShopContext())
            {
                context.Carts.Update(entity);

                context.SaveChanges();
            }
        }

        List<Cart> IRepository<Cart>.GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
