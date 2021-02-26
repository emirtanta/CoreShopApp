using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShopApp.WebUI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Display(Name = "Name", Prompt = "Enter product name")]
        public string Name { get; set; }

        public string Url { get; set; }

        [Required(ErrorMessage = "Fiyat belirtiniz")]
        [Range(1, 10000)]
        public double? Price { get; set; }


        [Required]
        [StringLength(10000, MinimumLength = 20, ErrorMessage = "Ürün açıklaması en az 20 en fazla 10000 karakter olabilir")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsApproved { get; set; }

        public bool IsHome { get; set; }

        //ürün ile ilişkili kategorileri getirir
        public List<Category> SelectedCategories { get; set; }
    }
}
