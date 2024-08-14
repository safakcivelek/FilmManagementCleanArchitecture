using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Concretes.Services;
using FilmManagement.Application.Rules;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using FilmManagement.Application.Pipelines.Validation;
using DirectorManagement.Application.Concretes.Services;


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
                configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));                 
            });

            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddFluentValidation()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            

            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IFilmActorService, FilmActorService>();
            services.AddScoped<IFilmGenreService, FilmGenreService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IFilmRatingService, FilmRatingService>();

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
