using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FilmManagement.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmActor> FilmActors { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 'ApplyConfigurationsFromAssembly' => belirtilen assembly'de bulunan tüm 'IEntityTypeConfiguration' arabirimini uygulayan sınıfları tarar ve bu sınıflarda tanımlanan yapılandırmaları otomatik olarak uygular.

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());          
        }
    }
}
