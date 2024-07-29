
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Concretes.Services;
using FilmManagement.Application.Rules;
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

            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

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

        public static IServiceCollection AddSubClassesOfType(
            this IServiceCollection services,
            Assembly assembly,
            Type type,
            Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
        )
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (Type? item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);
                else
                    addWithLifeCycle(services, type);
            return services;
        }
    }
}
