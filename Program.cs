using ImportFile_excel.Models;
using ImportFile_excel.Repository;
using Microsoft.EntityFrameworkCore;

namespace ImportFile_excel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); //AddRazorRuntimeCompilation change html css Page Not Refreshing After Changes
            builder.Services.AddDbContext<CustDbcontext>(conn => conn.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnection")));
            builder.Services.AddScoped<IConvertDate, ConvertDateDetail>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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