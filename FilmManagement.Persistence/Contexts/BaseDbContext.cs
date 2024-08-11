using FilmManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FilmManagement.Persistence.Contexts
{
    public class BaseDbContext : IdentityDbContext<User, Role, Guid>
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Actor> Actors { get; set; }      
        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmActor> FilmActors { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<FilmRating> FilmRatings { get; set; }
        //public DbSet<User> Users { get; set; } //Buraya eklemeye gerek yok otomatik oluşuyor.
        //public DbSet<Role> Roles { get; set; } //Buraya eklemeye gerek yok otomatik oluşuyor.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 'ApplyConfigurationsFromAssembly' => belirtilen assembly'de bulunan tüm 'IEntityTypeConfiguration' arabirimini uygulayan sınıfları tarar ve bu sınıflarda tanımlanan yapılandırmaları otomatik olarak uygular.

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());          
        }
    }
}
