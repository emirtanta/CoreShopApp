using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreShopApp.Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);

        Product GetByIdWithCategories(int id);

        Product GetByProductDetails(string url);

        List<Product> GetByProductsByCategory(string name, int page, int pageSize);

        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);
        List<Product> GetAll();

        void Create(Product entity);

        void Update(Product entity);

        void Delete(Product entity);
        int GetCountByCategory(string category);


        void Update(Product entity, int[] categoryIds);
    }
}
