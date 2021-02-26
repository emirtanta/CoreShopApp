using CoreShopApp.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreShopApp.Data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public Product GetByIdWithCategories(int id)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(i => i.ProductId == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new ShopContext())
            {
                //asqueryable yazılmasının sebebi linq sorgusunun yazılabilmesidir
                var products = context.Products.Where(i => i.IsApproved).AsQueryable();

                if (string.IsNullOrEmpty(category))
                {
                    //ürünü kategorisne göre filtreledik
                    products = products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(a => a.Category.Url == category));

                }

                //skip metotdu sayfalama da ürün göstermek için tanımladık
                return products.Count();
            }
        }

        public List<Product> GetHomePageProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products.Where(i => i.IsApproved && i.IsHome == true).ToList();
            }
        }

        public List<Product> GetPopularProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProductDetails(string url)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(i => i.Url == url)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public Product GetProductDetaşls(string url)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            using (var context = new ShopContext())
            {
                //asqueryable yazılmasının sebebi linq sorgusunun yazılabilmesidir
                var products = context
                .Products
                .Where(i => i.IsApproved)
                .AsQueryable();

                if (string.IsNullOrEmpty(name))
                {
                    //ürünü kategorisne göre filtreledik
                    products = products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(a => a.Category.Url == name));

                }

                //skip metotdu sayfalama da ürün göstermek için tanımladık
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Product> GetSearchResult(string searchString)
        {
            using (var context = new ShopContext())
            {
                //asqueryable yazılmasının sebebi linq sorgusunun yazılabilmesidir
                var products = context
                .Products
                .Where(i => i.IsApproved && (i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.Contains(searchString.ToLower())))
                .AsQueryable();



                //skip metotdu sayfalama da ürün göstermek için tanımladık
                return products.ToList();
            }
        }

        public List<Product> GetTop5Products()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new ShopContext())
            {
                var product = context.Products
                    .Include(i => i.ProductCategories)
                    .FirstOrDefault(i => i.ProductId == entity.ProductId);

                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.Description = entity.Description;
                    product.Url = entity.Url;
                    product.ImageUrl = entity.ImageUrl;

                    product.ProductCategories = categoryIds.Select(catid => new ProductCategory()
                    {
                        ProductId = entity.ProductId,
                        CategoryId = catid
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
    }
}
