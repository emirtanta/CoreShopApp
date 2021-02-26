using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreShopApp.Data.Abstract
{
   public  interface IProductRepository:IRepository<Product>
    {
        Product GetProductDetaşls(string url);

        List<Product> GetProductsByCategory(string name, int page, int pageSize);

        List<Product> GetPopularProducts();

        List<Product> GetSearchResult(string searchString);

        List<Product> GetHomePageProducts();

        int GetCountByCategory(string category);

        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
    }
}
