using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetOps.Domain.Entities;

namespace NetOps.Infrastructure.Persistence.Configurations
{
    public class ServiceRequestConfiguration
        : IEntityTypeConfiguration<ServiceRequest>
    {
        public void Configure(
        EntityTypeBuilder<ServiceRequest> builder)
        {
            builder.ToTable("service_requests");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.Priority)
                .IsRequired();

            builder.Property(x => x.TechnicianId)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .IsRequired();
        }
    }
}
