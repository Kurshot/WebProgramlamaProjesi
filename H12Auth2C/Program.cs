using H12Auth2C.Data;
using H12Auth2C.Extensions;
using H12Auth2C.Middlewares;
using H12Auth2C.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace H12Auth2C
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            /////////////////////////////////////////////////////
            builder.Services.AddControllersWithViews()
                            .AddViewLocalization();

            builder.Services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new("tr-TR");

                CultureInfo[] cultures = new CultureInfo[]
                {
                    new("tr-TR"),
                    new("en-US"),
                };

                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });

            builder.Services.AddScoped<RequestLocalizationCookiesMiddleware>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<UserDetails, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
             .AddDefaultTokenProviders()
             .AddDefaultUI()
             .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            app.UseRequestLocalization();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<UserDetails>>();

                Task.Run(async () => await SeedData.Initialize(userManager, roleManager)).Wait();
            }


            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRequestLocalization();
            app.UseRequestLocalizationCookies();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Main}/{action=Main}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}