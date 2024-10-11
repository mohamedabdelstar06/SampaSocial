using Hangfire;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SempaSocial.BLL.Mapping;
using SempaSocial.BLL.Services.Abstraction;
using SempaSocial.BLL.Services.Implementation;
using SempaSocial.DAL.DB;
using SempaSocial.DAL.Entities;
using SempaSocial.DAL.Repo.Abstraction;
using SempaSocial.DAL.Repo.Impelementation;

namespace SempaSocial.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Enhancement ConnectionString
            var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
            builder.Services.AddDbContext<SempaSocialDbContext>(options =>
            options.UseSqlServer(connectionString));

            //Identity 
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                  options =>
           {
                options.LoginPath = new PathString("/Account/Login");
                options.AccessDeniedPath = new PathString("/Account/Login");
            });


            builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SempaSocialDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

            //Auto mapper
            builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));


            //Make Dependamcy Injection LifeTime Servies  Repo
            builder.Services.AddScoped<IUserRepo,UserRepo>();
            builder.Services.AddScoped<IPostRepo, PostRepo>();
            builder.Services.AddScoped<ICommentRepo, CommentRepo>();

            //Make Dependamcy Injection LifeTime Servies  Service
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IPostServices, PostServices>();




            //Hang Fire
            builder.Services.AddHangfire(x => x.UseSqlServerStorage(connectionString));
            builder.Services.AddHangfireServer();

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
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseHangfireDashboard("/HangeFire");
            app.Run();
        }
    }
}
