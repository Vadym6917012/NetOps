using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetOps.Application.Abstractions;
using NetOps.Infrastructure.Persistence;
using NetOps.Infrastructure.Persistence.Repositories;

namespace NetOps.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IServiceRequestRepository, ServiceRequestRepository>();

            return services;
        }
    }
}