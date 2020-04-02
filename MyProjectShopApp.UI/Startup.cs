using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyProjectShopApp.Business.Abstract;
using MyProjectShopApp.Business.Concrete;
using MyProjectShopApp.DAL.SeedDatabase;
using MyProjectShopApp.DataAccess.Abstract;
using MyProjectShopApp.DataAccess.Concrete.EfCore;
using MyProjectShopApp.DataAccess.Memory;
using MyProjectShopApp.UI.Identity;
using MyProjectShopApp.UI.Models.Identity;

namespace MyProjectShopApp.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();




            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICardRepository, EfCoreCardRepository>();
            services.AddScoped<ICardService, CardManager>();
            services.AddScoped<IOrderRepository, EfCoreOrderRepository>();
            services.AddScoped<IOrderService, OrderManager>();
            



            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {

                //password
                options.Password.RequireDigit = true;//Mutlaka say�sal bir de�er olmak zorunda
                options.Password.RequireLowercase = true; //Mutlaka k���k karakter olmak zorunda
                options.Password.RequiredLength = 7; //Karakter uzunlu�u en az 7 karakter olmak zorunda
                options.Password.RequireNonAlphanumeric = true; //Karaketer ve say� d���dna de�er girebilir
                options.Password.RequireUppercase = true;//B�y�k harf girmek zorunda

                options.Lockout.MaxFailedAccessAttempts = 3; //Ka� kere yanl�� de�er girebilir
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);//Kullan�c� 1 dk boyunca giri� yapamaz
                options.Lockout.AllowedForNewUsers = true; //Yeni kullan�c� i�in ge�erli olucak

                options.User.RequireUniqueEmail = true;//Tek bir mail ile giri� yapmaz zorunda

                options.SignIn.RequireConfirmedEmail = false; // Kullan�c� mail adresinde onay yapmas� laz�m
                options.SignIn.RequireConfirmedPhoneNumber = false; // Telefon numaras� onay� yoktur

            });

            //Cookie Ayarlar�

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";//Login sayfas�
                options.LogoutPath = "/Account/Logout"; //��k�� sayfas�
                options.AccessDeniedPath = "/Account/AccessDeniedPath";//Yetkisi yoksa bu sayfaya gider
                options.SlidingExpiration = true; //Belli bir s�re sonra cookie sona erer
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.Cookie = new CookieBuilder()
                {
                    HttpOnly = true, //Scriptler taraf�ndan cookie okunamaz
                    Name = "MyProjectShopApp.Security.Cookie", //Cookie ismi art�k bu g�z�k�r
                    SameSite = SameSiteMode.Strict //Bu cookie kullan�c�ya �zel olur




                };




            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();




            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                name: "Adminproducts",
                pattern: "admin/products",
                defaults: new { controller = "Admin", action = "ProductList" });


                endpoints.MapControllerRoute(
                name: "Adminproducts",
                pattern: "admin/products/{id}",
                defaults: new { controller = "Admin", action = "EditProduct" });

                endpoints.MapControllerRoute(
                name: "products",
                pattern: "products/{category?}",
                defaults: new { controller = "Shop", action = "List" });

                endpoints.MapControllerRoute(
                name: "Card",
                 pattern: "Card",
                defaults: new { controller = "Card", action = "Index" });

                endpoints.MapControllerRoute(
                name: "CheckOut",
                pattern: "CheckOut",
                defaults: new { controller = "Card", action = "CheckOut" });

                endpoints.MapControllerRoute(
                name: "Order",
                 pattern: "Order",
                defaults: new { controller = "Card", action = "GetOrders" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");










            });

            SeedIdentity.Seed(userManager, roleManager, Configuration).Wait();
        }
    }
}
