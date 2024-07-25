
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Concretes.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FilmManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerFavoriteGenreService, CustomerFavoriteGenreService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IFilmActorService, FilmActorService>();
            services.AddScoped<IFilmGenreService, FilmGenreService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IPurchaseService, PurchaseService>();

            return services;
        }
    }
}
