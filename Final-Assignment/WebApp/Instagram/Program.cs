using Instagram.BLL;
using Instagram.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace Instagram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register dbcontext with the connection string from appsettings.json.
            builder.Services.AddDbContext<InstagramContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register UserService in the injection dependencies container.
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<FollowerRepository>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<FollowerService>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
