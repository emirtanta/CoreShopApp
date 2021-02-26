﻿using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShopApp.WebUI.Models
{
    public class CategoryListViewModels
    {
        public string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
