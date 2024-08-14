using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;
using FilmManagement.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("FilmManagementConnectionString")));

            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IFilmActorRepository, FilmActorRepository>();
            services.AddScoped<IFilmGenreRepository, FilmGenreRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IFilmRatingRepository, FilmRatingRepository>();

            services.AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;

            })
                .AddEntityFrameworkStores<BaseDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
