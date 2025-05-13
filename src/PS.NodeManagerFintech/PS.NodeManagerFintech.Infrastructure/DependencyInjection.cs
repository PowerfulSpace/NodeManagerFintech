using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PS.NodeManagerFintech.Application.Interfaces;
using PS.NodeManagerFintech.Infrastructure.Persistence;
using PS.NodeManagerFintech.Infrastructure.Persistence.Repositories;

namespace PS.NodeManagerFintech.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
                .AddPersistance(configuration);

            return services;
        }

        private static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("NodeManagerDb")));

            services.AddScoped<ITreeRepository, TreeRepository>();
            services.AddScoped<ITreeNodeRepository, TreeNodeRepository>();
            services.AddScoped<IExceptionLogRepository, ExceptionLogRepository>();

            return services;
        }
    }
}
