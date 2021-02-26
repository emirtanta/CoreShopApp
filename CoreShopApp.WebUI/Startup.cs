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

            //IdentityDb i�in sql yolu
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            //parola resetlemek i�in
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            //kullan�c� kay�t olma ayarlar�
            services.Configure<IdentityOptions>(options =>
            {
                //parola ayarlar�
                options.Password.RequireDigit = true; //dijital karakter i�ermeli
                options.Password.RequireLowercase = true; //k���k harf i�ermeli
                options.Password.RequireUppercase = true; //b�y�k harf i�ermeli
                options.Password.RequiredLength = 6;//en az 6 karakterlik parola
                options.Password.RequireNonAlphanumeric = true;//alfa n�merik karakter i�ermeli

                //lokout kullan�c�n�n hesab� kilitlendi�indeki ayarlar
                options.Lockout.MaxFailedAccessAttempts = 5; //en fazla 5 kez parola yanl�� girme hakk�
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);//5 dakika sonra ��k�� yapt�rma (iste�e ba�l�)

                //user ayarlar�
                //options.User.AllowedUserNameCharacters = ""; //username i�erisinde olmas� gereken de�erleri ayarlar
                options.User.RequireUniqueEmail = true;//her kullan�c�n�n kendine �zg� bir emaik olmas� kural�
                options.SignIn.RequireConfirmedEmail = true;//kullan�c�n�n hesab�n�n nay maili ile onaylanmas�n� sa�lar(true olursa)
                //options.SignIn.RequireConfirmedPhoneNumber = true; //hesab�n�n onay almas� i�in sms ile onaylanmas�n� sa�lar

            });

            //cookie ayarlar�
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";//��k�� yap�ld���nda y�nlendirilecek giri� adresi
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";//yetkisi olmayan kullan�c�lar�n yetkisi olan sayfalara gidilmemesi i�in gittikleri sayfa yolu
                options.SlidingExpiration = true;//cookienin s�resi(varsay�lan ayar 20 dakikad�r)
                options.ExpireTimeSpan = TimeSpan.FromDays(365);//cookinin 365 g�n ge�erkli olmas�n� sa�lar
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,//sadece taray�c�dan cookie'ye ula�may� sa�lar

                    SameSite=SameSiteMode.Strict //csrf token i�in form g�venli�ni sa�lar
                };
            });

            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<ICartRepository, EfCoreCartRepository>();
            services.AddScoped<IOrderRepository, EfCoreOrderRepository>();

            //business katman�n�n �al��abilmesi i�in tan�mlad�k
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<IOrderService, OrderManager>();


            //email g�nderme ayarlar�
            services.AddScoped<IEmailSender, SmtpEmailSender>(x =>

            new SmtpEmailSender(
                _configuration["EmailSender:Host"],
                _configuration.GetValue<int>("EmailSender:Port"),
                _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                _configuration["EmailSender:UserName"],
                _configuration["EmailSender:Password"]
            ));

            //mvc yap�s� i�in tan�mlad�k
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

            //wwwroot klas�r�ne eri�ebilmek i�in tan�mlad�k
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();//IdentityDb i�in eklendi

            //test verilerinin veritaban�na y�klenebilmesi i�in tan�mlad�k
            //SeedIdentity.Seed(userManager, roleManager, configuration).Wait();

            app.UseEndpoints(endpoints =>
            {

                //user edit i�in rota yolu
                endpoints.MapControllerRoute(
                    name: "useredit",
                    pattern: "user/{id?}",
                    defaults: new { controller = "Rols", action = "UserEdit" });

                //user list i�in rota yolu
                endpoints.MapControllerRoute(
                    name: "users",
                    pattern: "user/list",
                    defaults: new { controller = "Rols", action = "UserList" });

                //rol listesi i�in
                endpoints.MapControllerRoute(
                    name: "roles",
                    pattern: "{controller=Rols}/{action=RoleList}");

                //rol create i�in
                endpoints.MapControllerRoute(
                    name: "rolecreate",
                    pattern: "{controller=Rols}/{action=RoleCreate}",
                     defaults: new { controller = "Rols", action = "RoleCreate" });

                //rol edit i�in
                endpoints.MapControllerRoute(
                    name: "roleedit",
                    pattern: "role/{id?}",
                    defaults: new { controller = "Rols", action = "RolEdit" });

                //�r�n ekleme rota yolu
                endpoints.MapControllerRoute(
                    name: "adminprodtccreate",
                    pattern: "admin/producs/create",
                    defaults: new { controller = "Admin", action = "ProductCreate" }
                );

                //�r�n g�ncelleme rotas� tan�mlad�k
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

                //kategori g�ncelleme rotas� tan�mlad�k
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
