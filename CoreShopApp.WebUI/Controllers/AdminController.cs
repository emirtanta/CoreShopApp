using CoreShopApp.Business.Abstract;
using CoreShopApp.WebUI.Extensions;
using CoreShopApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShopApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        #region Inject Bölgesi

        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        #endregion

        #region Product CRUD Bölgesi

        #region Ürünler Listesi Bölgesi

        public IActionResult ProductList()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            }); 
        }

        #endregion

        #region Ürün Ekleme Bölgesi

        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProductCreate(ProductModel model)
        {
            var entity = new Product()
            {
                Name=model.Name,
                Url=model.Url,
                Price=model.Price,
                Description=model.Description,
                ImageUrl=model.ImageUrl
            };

            _productService.Create(entity);

            //alert mesajları içerikleri
            TempData.Put("message", new AlertMessage()

            {
                Title = "Ürün eklendi",
                Message = $"{entity.Name} isimli ürün eklendi",
                AlertType = "success"
            });

            return RedirectToAction("ProductList", "Admin");

        }

        #endregion

        #region Ürün Güncelleme Bölgesi

        [HttpGet]
        public IActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _productService.GetByIdWithCategories((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new ProductModel()
            {
                ProductId = entity.ProductId,
                Name = entity.Name,
                Url = entity.Url,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Description = entity.Description,
                //ürün ile ilgili kategorileri getirir
                SelectedCategories = entity.ProductCategories.Select(i => i.Category).ToList()
            };

            //bütün kategorileri getirir
            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
        }

        [HttpPost]
        public IActionResult ProductEdit(ProductModel model, int[] categoryIds)
        {
            var entity = _productService.GetById(model.ProductId);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Url = model.Url;
            entity.ImageUrl = model.ImageUrl;
            entity.Description = model.Description;



            _productService.Update(entity, categoryIds);

            //alert mesajları içerikleri
            TempData.Put("message", new AlertMessage()
            {
                Title = "Ürün Güncelleme",
                Message = $"{entity.Name} isimli ürün güncellendi",
                AlertType = "info"
            });

            return RedirectToAction("ProductList");
        }

        #endregion

        #region Ürün Silme Bölgesi

        public IActionResult ProductDelete(int productId)
        {
            var entity = _productService.GetById(productId);

            if (entity!=null)
            {
                _productService.Delete(entity);
            }

            //alert mesajları içerikleri
            TempData.Put("message", new AlertMessage()
            {
                Title = "Ürün Silme",
                Message = $"{entity.Name} isimli ürün silindi",
                AlertType = "danger"
            });

            return RedirectToAction("ProductList", "Admin");
        }

        #endregion

        #endregion

        #region Kategori CRUD İşlemleri Bölgesi

        #region Kategori Listesi Bölgesi

        public IActionResult CategoryList()
        {
            return View(new CategoryListViewModels()
            {
                Categories = _categoryService.GetAll()
            }); ;
        }

        #endregion

        #region Kategori Ekleme Bölgesi

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model)
        {
            var entity = new Category()
            {
                Name=model.Name,
                Url=model.Url
            };

            _categoryService.Create(entity);

            //alert mesajları içerikleri
            TempData.Put("message", new AlertMessage()
            {
                Title = "Kategori Ekleme",
                Message = $"{entity.Name} isimli kategori eklendi",
                AlertType = "success"
            });

            return RedirectToAction("CategoryList", "Admin");
        }

        #endregion

        #region Kategori Düzenleme Bölgesi

        [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _categoryService.GetByWithProducts((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new CategoryModel()
            {
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                Url = entity.Url,
                Products = entity.ProductCategories.Select(p => p.Product).ToList()
            };

            return View(model);

        }

        [HttpPost]
        public IActionResult CategoryEdit(int id,CategoryModel model)
        {
            var entity = _categoryService.GetById(model.CategoryId);

            if (entity==null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            entity.Url = model.Url;

            _categoryService.Update(entity);

            //alert mesajları içerikleri
            TempData.Put("message", new AlertMessage()
            {
                Title = "Kategori Gücelleme",
                Message = $"{entity.Name} isimli kategori güncellendi",
                AlertType = "info"
            });

            return RedirectToAction("CategoryList", "Admin");

        }

        #endregion

        #region Kategori Silme Bölgesi

        public IActionResult CategoryDelete(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);

            if (entity!=null)
            {
                _categoryService.Delete(entity);
            }

            //alert mesajları içerikleri
            TempData.Put("message", new AlertMessage()
            {
                Title = "Kategori Silme",
                Message = $"{entity.Name} isimli kategori silindi",
                AlertType = "danger"
            });

            return RedirectToAction("CategoryList", "Admin");

        }

        #endregion

        #region Kategoriden Ürün Silme

        [HttpPost]
        public IActionResult DeleteFromCategory(int productId,int categoryId)
        {
            _categoryService.DeleteFromCategory(productId, categoryId);

            return Redirect("/admin/categories/" + categoryId);
        }

        #endregion

        #endregion

    }
}
