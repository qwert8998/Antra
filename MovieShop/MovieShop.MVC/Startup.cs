using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using Infrastructure.Data;
using Infrastructure.Helpers;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieShop.MVC.Filters;
using System;

namespace MovieShop.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Configuration reads appsetting.json
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //all controller inherent MovieShopHeaderFilter
            services.AddControllersWithViews(options =>
                options.Filters.Add(typeof(MovieShopHeaderFilter))
            );
            //inject filter can be done in specific action
            services.AddScoped<MovieShopHeaderFilter>();

            //inject connectionstring into Infrastructure.Data.MovieShopDBContext constructor
            services.AddDbContext<MovieShopDBContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("MovieShop")
            ));
            //Injecting MovieService entiity for IMovieService interface
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreService,GenreService>();
            services.AddScoped<IGenreRepository,GenreRepository>();
            services.AddScoped<ICastRepository,CastRepository>();
            services.AddScoped<ICastService,CastService>();
            services.AddScoped<IMovieCastRepository,MovieCastRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IAsyncRepository<Genre>, EfRepository<Genre>>();
            services.AddScoped<ICurrentUserService,CurrentUserService>();
            services.AddScoped<IPurchaseRepository,PurchaseRepository>();
            services.AddScoped<IFavoriteRepository,FavoriteReposiotry>();
            services.AddScoped<IReviewRepository,ReviewRepository>();

            services.AddAutoMapper(typeof(Startup), typeof(MovieShopMappingProfile));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option => {
                    option.Cookie.Name = "MovieShpAuthCookie";
                    option.ExpireTimeSpan = TimeSpan.FromHours(2);
                    option.LoginPath = "/Account/Login";
                });
            services.AddHttpContextAccessor();
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
            //for example, some images, json files

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
