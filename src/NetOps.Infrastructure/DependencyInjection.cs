using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetOps.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

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

            return services;
        }
    }
}
