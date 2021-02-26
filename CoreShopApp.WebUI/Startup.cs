using CoreShopApp.Business.Abstract;
using CoreShopApp.Business.Concrete;
using CoreShopApp.Data.Abstract;
using CoreShopApp.Data.Concrete.EfCore;
using CoreShopApp.WebUI.EMailService;
using CoreShopApp.WebUI.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShopApp.WebUI
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            //Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Data Source=ShopDB"));

            //IdentityDb için sql yolu
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            //parola resetlemek için
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            //kullanýcý kayýt olma ayarlarý
            services.Configure<IdentityOptions>(options =>
            {
                //parola ayarlarý
                options.Password.RequireDigit = true; //dijital karakter içermeli
                options.Password.RequireLowercase = true; //küçük harf içermeli
                options.Password.RequireUppercase = true; //büyük harf içermeli
                options.Password.RequiredLength = 6;//en az 6 karakterlik parola
                options.Password.RequireNonAlphanumeric = true;//alfa nümerik karakter içermeli

                //lokout kullanýcýnýn hesabý kilitlendiðindeki ayarlar
                options.Lockout.MaxFailedAccessAttempts = 5; //en fazla 5 kez parola yanlýþ girme hakký
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);//5 dakika sonra çýkýþ yaptýrma (isteðe baðlý)

                //user ayarlarý
                //options.User.AllowedUserNameCharacters = ""; //username içerisinde olmasý gereken deðerleri ayarlar
                options.User.RequireUniqueEmail = true;//her kullanýcýnýn kendine özgü bir emaik olmasý kuralý
                options.SignIn.RequireConfirmedEmail = true;//kullanýcýnýn hesabýnýn nay maili ile onaylanmasýný saðlar(true olursa)
                //options.SignIn.RequireConfirmedPhoneNumber = true; //hesabýnýn onay almasý için sms ile onaylanmasýný saðlar

            });

            //cookie ayarlarý
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";//çýkýþ yapýldýðýnda yönlendirilecek giriþ adresi
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";//yetkisi olmayan kullanýcýlarýn yetkisi olan sayfalara gidilmemesi için gittikleri sayfa yolu
                options.SlidingExpiration = true;//cookienin süresi(varsayýlan ayar 20 dakikadýr)
                options.ExpireTimeSpan = TimeSpan.FromDays(365);//cookinin 365 gün geçerkli olmasýný saðlar
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,//sadece tarayýcýdan cookie'ye ulaþmayý saðlar

                    SameSite=SameSiteMode.Strict //csrf token için form güvenliðni saðlar
                };
            });

            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<ICartRepository, EfCoreCartRepository>();
            services.AddScoped<IOrderRepository, EfCoreOrderRepository>();

            //business katmanýnýn çalýþabilmesi için tanýmladýk
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<IOrderService, OrderManager>();


            //email gönderme ayarlarý
            services.AddScoped<IEmailSender, SmtpEmailSender>(x =>

            new SmtpEmailSender(
                _configuration["EmailSender:Host"],
                _configuration.GetValue<int>("EmailSender:Port"),
                _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                _configuration["EmailSender:UserName"],
                _configuration["EmailSender:Password"]
            ));

            //mvc yapýsý için tanýmladýk
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            //wwwroot klasörüne eriþebilmek için tanýmladýk
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();//IdentityDb için eklendi

            //test verilerinin veritabanýna yüklenebilmesi için tanýmladýk
            //SeedIdentity.Seed(userManager, roleManager, configuration).Wait();

            app.UseEndpoints(endpoints =>
            {

                //user edit için rota yolu
                endpoints.MapControllerRoute(
                    name: "useredit",
                    pattern: "user/{id?}",
                    defaults: new { controller = "Rols", action = "UserEdit" });

                //user list için rota yolu
                endpoints.MapControllerRoute(
                    name: "users",
                    pattern: "user/list",
                    defaults: new { controller = "Rols", action = "UserList" });

                //rol listesi için
                endpoints.MapControllerRoute(
                    name: "roles",
                    pattern: "{controller=Rols}/{action=RoleList}");

                //rol create için
                endpoints.MapControllerRoute(
                    name: "rolecreate",
                    pattern: "{controller=Rols}/{action=RoleCreate}",
                     defaults: new { controller = "Rols", action = "RoleCreate" });

                //rol edit için
                endpoints.MapControllerRoute(
                    name: "roleedit",
                    pattern: "role/{id?}",
                    defaults: new { controller = "Rols", action = "RolEdit" });

                //ürün ekleme rota yolu
                endpoints.MapControllerRoute(
                    name: "adminprodtccreate",
                    pattern: "admin/producs/create",
                    defaults: new { controller = "Admin", action = "ProductCreate" }
                );

                //ürün güncelleme rotasý tanýmladýk
                endpoints.MapControllerRoute(
                    name: "adminproducedit",
                    pattern: "admin/products/{id?}",
                    defaults: new { controller = "Admin", action = "Edit" }
                );

                //kategori listesi rota yolu
                endpoints.MapControllerRoute(
                    name: "admincategories",
                    pattern: "admin/categories",
                    defaults: new { controller = "Admin", action = "CategoryList" }
                );

                //kategori ekleme rota yolu
                endpoints.MapControllerRoute(
                    name: "admincategorycreate",
                    pattern: "admin/categories/create",
                    defaults: new { controller = "Admin", action = "CategoryCreate" }
                );

                //kategori güncelleme rotasý tanýmladýk
                endpoints.MapControllerRoute(
                    name: "admincategoryedit",
                    pattern: "admin/categories/{id?}",
                    defaults: new { controller = "Admin", action = "CategoryEdit" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
