using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1_SozialMediaPlatform01.Data;
namespace WebApplication1_SozialMediaPlatform01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WebApplication1_SozialMediaPlatform01Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication1_SozialMediaPlatform01Context") ?? throw new InvalidOperationException("Connection string 'WebApplication1_SozialMediaPlatform01Context' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
