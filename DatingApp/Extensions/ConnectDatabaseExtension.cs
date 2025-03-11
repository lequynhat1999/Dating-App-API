using DatingApp.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Extensions
{
    public static class ConnectDatabaseExtension
    {
        public static IServiceCollection ConnectDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatingAppContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
