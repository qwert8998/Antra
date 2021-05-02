using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieShopDBContext: DbContext
    {
        public MovieShopDBContext(DbContextOptions<MovieShopDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieCast>().HasKey(x => new { x.CastId,x.MovieId,x.Character });
            builder.Entity<MovieCrew>().HasKey(x => new { x.MovieId,x.CrewId,x.Department,x.Job });
            builder.Entity<MovieGenre>().HasKey(x => new { x.MovieId,x.GenreId });
            builder.Entity<Review>().HasKey(x => new { x.MovieId,x.UserId });
            builder.Entity<UserRole>().HasKey(x => new { x.RoleId,x.UserId });
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Cast> Casts { get; set; }
    }
}
