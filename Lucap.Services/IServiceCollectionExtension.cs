using Lucap.Repositories;
using Lucap.Services.Interfaces;
using Lucap.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lucap.Services
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddLucapServices(this IServiceCollection services)
        {
            services.AddScoped<IConnectionService, ConnectionService>();
            services.AddLucapRepositories();
            return services;
        }
    }
}
