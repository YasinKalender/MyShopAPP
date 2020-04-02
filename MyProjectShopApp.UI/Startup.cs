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
                options.Password.RequireDigit = true;//Mutlaka sayýsal bir deðer olmak zorunda
                options.Password.RequireLowercase = true; //Mutlaka küçük karakter olmak zorunda
                options.Password.RequiredLength = 7; //Karakter uzunluðu en az 7 karakter olmak zorunda
                options.Password.RequireNonAlphanumeric = true; //Karaketer ve sayý dýþýdna deðer girebilir
                options.Password.RequireUppercase = true;//Büyük harf girmek zorunda

                options.Lockout.MaxFailedAccessAttempts = 3; //Kaç kere yanlýþ deðer girebilir
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);//Kullanýcý 1 dk boyunca giriþ yapamaz
                options.Lockout.AllowedForNewUsers = true; //Yeni kullanýcý için geçerli olucak

                options.User.RequireUniqueEmail = true;//Tek bir mail ile giriþ yapmaz zorunda

                options.SignIn.RequireConfirmedEmail = false; // Kullanýcý mail adresinde onay yapmasý lazým
                options.SignIn.RequireConfirmedPhoneNumber = false; // Telefon numarasý onayý yoktur

            });

            //Cookie Ayarlarý

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";//Login sayfasý
                options.LogoutPath = "/Account/Logout"; //Çýkýþ sayfasý
                options.AccessDeniedPath = "/Account/AccessDeniedPath";//Yetkisi yoksa bu sayfaya gider
                options.SlidingExpiration = true; //Belli bir süre sonra cookie sona erer
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.Cookie = new CookieBuilder()
                {
                    HttpOnly = true, //Scriptler tarafýndan cookie okunamaz
                    Name = "MyProjectShopApp.Security.Cookie", //Cookie ismi artýk bu gözükür
                    SameSite = SameSiteMode.Strict //Bu cookie kullanýcýya özel olur




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
