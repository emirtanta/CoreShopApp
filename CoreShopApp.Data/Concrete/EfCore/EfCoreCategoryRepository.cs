using CoreShopApp.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreShopApp.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        public void DeleteFromCategory(int productId, int categoryId)
        {
            using (var context = new ShopContext())
            {
                var cmd = "delete from productcategory where ProductId=@p0 and CategoryId=@p1";

                context.Database.ExecuteSqlRaw(cmd, productId, categoryId);
            }
        }

        public Category GetByWithProducts(int categoryId)
        {
            using (var context = new ShopContext())
            {
                return context.Categories
                    .Where(i => i.CategoryId == categoryId)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault();
            }
        }

        public List<Category> GetPopularCategories()
        {
            throw new NotImplementedException();
        }
    }
}
