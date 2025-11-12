using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;               // IWebHostEnvironment
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;                // <-- нужный using
using PetShop.Data;
using Microsoft.EntityFrameworkCore;

namespace PetShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // -------------------------------------------------
        // 1. Регистрация сервисов
        // -------------------------------------------------
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // SQLite (файл будет создан автоматически)
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=petshop.db"));

            services.AddAuthentication(
                    Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/Login";
                    options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
                });

            services.AddAuthorization();
        }

        // -------------------------------------------------
        // 2. Конфигурация пайплайна
        // -------------------------------------------------
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ---- Создаём базу и таблицы при первом запуске ----
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                ctx.Database.EnsureCreated();   // <-- создаёт petshop.db и все DbSet-ы
            }

            // ---- Development / Production ----
            if (!env.IsDevelopment())   // <-- теперь работает
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}