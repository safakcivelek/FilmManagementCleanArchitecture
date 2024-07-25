using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Persistence.Contexts;
using FilmManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("FilmManagementConnectionString")));

            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerFavoriteGenreRepository, CustomerFavoriteGenreRepository>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IFilmActorRepository, FilmActorRepository>();
            services.AddScoped<IFilmGenreRepository, FilmGenreRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();

            return services;
        }
    }
}
