using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreShopApp.Data.Abstract
{
    public interface ICartRepository:IRepository<Cart>
    {
        Cart GetByUserId(string userId);

        //kart içerisinden veri silme
        void DeleteFromCart(int cartId, int productId);

        //kartı temizleme
        void ClearCart(string cartId);
    }
}
