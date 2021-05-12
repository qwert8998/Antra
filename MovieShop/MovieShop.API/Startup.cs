using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using Infrastructure.Data;
using Infrastructure.Helpers;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieShop.API.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API
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

            services.AddControllers();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ICastRepository, CastRepository>();
            services.AddScoped<ICastService, CastService>();
            services.AddScoped<IMovieCastRepository, MovieCastRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAsyncRepository<Genre>, EfRepository<Genre>>();
            services.AddScoped<IPurchaseRepository,PurchaseRepository>();
            services.AddScoped<IFavoriteRepository,FavoriteReposiotry>();
            services.AddScoped<IReviewRepository,ReviewRepository>();

            services.AddDbContext<MovieShopDBContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("MovieShop")
            ));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieShop.API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup), typeof(MovieShopMappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseMovieShopExceptionMiddleware();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieShop.API v1"));
            }

            app.UseHttpsRedirection();
            //app.UseStaticFiles(); --does not need, API only delivery data (not like MVC)

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
