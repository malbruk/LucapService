using Lucap.Repositories.Interfaces;
using Lucap.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucap.Repositories
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddLucapRepositories(this IServiceCollection services)
        {
            services.AddScoped<IConnectionRepository, ConnectionRepository>();
            return services;
        }
    }
}
