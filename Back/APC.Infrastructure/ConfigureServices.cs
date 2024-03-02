using APC.Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbContext>(p => p.GetRequiredService<ApplicationDbContext>());

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("APC_DB"));

            return services;

        }

    }
}