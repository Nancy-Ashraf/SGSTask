using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SGS.BL;
using SGS.DAL;
using SGS.DAL.Scaffold;
using System.Data;

namespace SGS
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IKPIRepository, KPIRepository>();
            builder.Services.AddScoped<IKPIManager, KPIManager>();
            builder.Services.AddDbContext<ConfigDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });


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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
