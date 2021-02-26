using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreShopApp.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId);

        //kullanıcının kartını getirme
        Cart GetCartByUserId(string userId);

        //karta ürün ekleme
        void AddToCart(string userId, int productId, int quantity);


        //karttan ürün silme
        void DeleteFromCart(string userId, int productId);


        //kartı temizleme
        void ClearCart(string cartId);
    }
}
