using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.WindowsServices;
using Web_bestcoder.Data;

namespace Web_bestcoder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (WindowsServiceHelpers.IsWindowsService())
            {
                builder.Host.UseWindowsService();
            }

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<GreenCoderContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("GreenCoder"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Area route configuration
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            // Default route configuration
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
