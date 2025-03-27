using DatingApp.Interfaces;
using DatingApp.Repository;
using DatingApp.Services;

namespace DatingApp.Extensions
{
    public static class RegisterDependencyInjectionExtension
    {
        public static IServiceCollection RegisterDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
