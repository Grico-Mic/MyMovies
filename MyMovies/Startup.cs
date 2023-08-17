using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movies.Servises;
using MyMovies.Common.Options;
using MyMovies.Repositories;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
using MyMovies.Servises;
using MyMovies.Servises.Interfaces;
using System;

namespace MyMovies
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
            //config for LazyLoading
           // services.AddDbContext<MyMoviesDbContext>(x => x.UseLazyLoadingProxies()
           //.UseSqlServer("Server=DESCTOP-V9GRIC;Database=MyMovies;Trusted_Connection=true;"));

            services.AddDbContext<MyMoviesDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("MyMovies")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(int.Parse(Configuration["CookieExpirationPeriod"]));
                    options.SlidingExpiration = true;
                    options.LoginPath = "/Auth/SignIn";
                    options.AccessDeniedPath = "/Auth/AccessDenied";
                }

                );

            //configure options
            services.Configure<SidebarConfig>(Configuration.GetSection("SidebarConfig"));


            services.AddAuthorization(options =>
                {
                    options.AddPolicy("IsAdmin", policy =>
                    {
                        policy.RequireClaim("IsAdmin", "True");
         
                    });
                });



            services.AddControllersWithViews();

            services.AddTransient<IMoviesServise,MoviesServise>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<ISidebarService, SidebarService>();

            services.AddTransient<IMoviesRepository, MoviesRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<ICommentsRepository, CommentsRepository>();

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
                    name: "default",
                    pattern: "{controller=Movies}/{action=Overview}/{id?}");
            });
        }
    }
}
