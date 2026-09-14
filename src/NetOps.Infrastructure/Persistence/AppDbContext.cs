using Microsoft.EntityFrameworkCore;
using NetOps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetOps.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceRequest> ServiceRequests => Set<ServiceRequest> ();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
