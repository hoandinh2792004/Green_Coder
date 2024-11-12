using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.WindowsServices;

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
            
            // Add session services to the DI container
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);  // Set session timeout if needed
                options.Cookie.HttpOnly = true;  // For security reasons
                options.Cookie.IsEssential = true;  // Ensure session cookie is essential
            });

            // Add authentication services
            builder.Services.AddAuthentication("YourCookieScheme")
                .AddCookie("YourCookieScheme", options =>
                {
                    options.LoginPath = "/Login"; // Redirect here if not authenticated
                    options.AccessDeniedPath = "/AccessDenied"; // Path for access denied
                });

            // Add services to the container
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Add session middleware before routing
            app.UseSession();

            // Add authentication middleware before routing
            app.UseAuthentication(); // Make sure to add authentication middleware

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // Map area and default controller routes
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            // Map default controller route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
