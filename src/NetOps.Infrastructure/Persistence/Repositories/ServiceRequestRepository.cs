using Microsoft.EntityFrameworkCore;
using NetOps.Application.Abstractions;
using NetOps.Domain.Entities;

namespace NetOps.Infrastructure.Persistence.Repositories
{
    public sealed class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly AppDbContext _context;

        public ServiceRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            ServiceRequest request,
            CancellationToken cancellationToken)
        {
            await _context.ServiceRequests.AddAsync(
                request,
                cancellationToken);
        }

        public async Task<ServiceRequest?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken)
        {
            return await _context.ServiceRequests
                .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
        }

        public async Task<IReadOnlyList<ServiceRequest>> GetAllAsync(
            CancellationToken cancellationToken)
        {
            return await _context.ServiceRequests
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}