using Microsoft.EntityFrameworkCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreShopApp.Data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }

                //test ürün eklendi
                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategories);
                }
            }

            context.SaveChanges();
        }

        private static Category[] Categories =
        {
            new Category(){Name="Telefon",Url="telefon"},
            new Category(){Name="Bilgisayar",Url="bilgisayar"},
            new Category(){Name="Elektronik",Url="elektronik"}
        };

        private static Product[] Products =
        {
            new Product(){Name="Samsung s5",Url="samsung-s5",Price=2000,ImageUrl="ajax.png",Description="iyi telefon",IsApproved=true},
            new Product(){Name="Samsung s6",Url="samsung-s6",Price=3000,ImageUrl="atalanta.png",Description="iyi telefon",IsApproved=false},
            new Product(){Name="Samsung s7",Url="samsung-s7",Price=4000,ImageUrl="atletico_madrid.png",Description="iyi telefon",IsApproved=true},
            new Product(){Name="Samsung s8",Url="samsung-s8",Price=5000,ImageUrl="b_dortmund.png",Description="iyi telefon",IsApproved=false},
            new Product(){Name="Samsung s9",Url="samsung-s9",Price=6000,ImageUrl="barcelona.png",Description="iyi telefon",IsApproved=true}
        };

        //product ile category arasındaki çoka çok ilişki
        private static ProductCategory[] ProductCategories ={
            new ProductCategory(){Product=Products[0],Category=Categories[0]},
            new ProductCategory(){Product=Products[0],Category=Categories[2]},
            new ProductCategory(){Product=Products[1],Category=Categories[0]},
            new ProductCategory(){Product=Products[1],Category=Categories[1]},
            new ProductCategory(){Product=Products[2],Category=Categories[0]},
            new ProductCategory(){Product=Products[2],Category=Categories[2]},
            new ProductCategory(){Product=Products[3],Category=Categories[1]}
        };


    }
}
