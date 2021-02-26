using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        //product ile category arasındaki çoka çok ilişki

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
