using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            //builder.Entity<MovieGenre>().HasKey(x => new { x.MovieId,x.GenreId });
            builder.Entity<Review>().HasKey(x => new { x.MovieId,x.UserId });
            builder.Entity<UserRole>().HasKey(x => new { x.RoleId,x.UserId });
            builder.Entity<Movie>(ConfigureMovie);
            builder.Entity<Trailer>(ConfigureTrailer);
            builder.Entity<User>(ConfigureUser);

            //create MovieGenre table using Linq statement
            builder.Entity<Movie>().HasMany(m => m.Genres).WithMany(g => g.Movies)
               .UsingEntity<Dictionary<string, object>>("MovieGenre",
                   m => m.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                   g => g.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));
        }
        
        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(u => u.FirstName).HasMaxLength(128);
            builder.Property(u => u.LastName).HasMaxLength(128);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.HashedPassword).HasMaxLength(1024);
            builder.Property(u => u.Salt).HasMaxLength(1024);
            builder.Property(u => u.PhoneNumber).HasMaxLength(16);
            builder.Property(u => u.IsLocked).HasDefaultValue(false);
        }

        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
            builder.Property(t => t.Name).HasMaxLength(2084);
        }

        private void ConfigureMovie (EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Ignore(m => m.Rating);
        }

        public DbSet<Genre> Genres { get; set; }
        //public DbSet<MovieGenre> MovieGenres { get; set; }
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
