using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreShopApp.Data.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
        List<Category> GetPopularCategories();

        //kategoriye ait ürünleri getirir
        Category GetByWithProducts(int categoryId);

        void DeleteFromCategory(int productId, int categoryId);
    }
}
