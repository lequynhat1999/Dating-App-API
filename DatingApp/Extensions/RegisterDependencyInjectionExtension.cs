using DatingApp.Interfaces;
using DatingApp.Services;

namespace DatingApp.Extensions
{
    public static class RegisterDependencyInjectionExtension
    {
        public static IServiceCollection RegisterDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
