using CoreShopApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShopApp.WebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        //dependency injection işlemi
        private ICategoryService _categoryService;

        //dependency injection işlemi
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            //aktif class ı için tanımladık
            if (RouteData.Values["category"] != null)
            {

                ViewBag.SelectedCategory = RouteData?.Values["category"];
            }


            return View(_categoryService.GetAll());
        }
    }
}
