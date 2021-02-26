using CoreShopApp.Business.Abstract;
using CoreShopApp.Data.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreShopApp.Business.Concrete
{
    public class CartManager : ICartService
    {

        private ICartRepository _cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        //karta ürün ekleme
        public void AddToCart(string userId, int productId, int quantity)
        {
            var cart = GetCartByUserId(userId);

            if (cart!=null)
            {
                //eklenmek isteyen ürün sepette var mı(güncelleme)
                var index = cart.CartItems.FindIndex(x => x.ProductId == productId);

                if (index<0)
                {
                    cart.CartItems.Add(new CartItem()
                    {
                        ProductId=productId,
                        Quantity=quantity,
                        CartId=cart.Id
                    });
                }

                //listede ürün varsa
                else
                {
                    //fiyatı arttırma
                    cart.CartItems[index].Quantity += quantity;
                }

                _cartRepository.Update(cart);
            }
        }

        public void ClearCart(string cartId)
        {
            _cartRepository.ClearCart(cartId);
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);

            if (cart!=null)
            {
                _cartRepository.DeleteFromCart(cart.Id, productId);
            }
        }

        //kullanıcının kartı
        public Cart GetCartByUserId(string userId)
        {
            return _cartRepository.GetByUserId(userId);
        }

        public void InitializeCart(string userId)
        {
            _cartRepository.Create(new Cart() { UserId = userId });
        }
    }
}
