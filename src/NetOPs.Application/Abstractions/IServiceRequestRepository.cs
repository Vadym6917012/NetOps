using NetOps.Domain.Entities;

namespace NetOps.Application.Abstractions
{
    public interface IServiceRequestRepository
    {
        Task AddAsync(
            ServiceRequest request,
            CancellationToken cancellationToken);

        Task<ServiceRequest?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken);

        Task<IReadOnlyList<ServiceRequest>> GetAllAsync(
            CancellationToken cancellationToken);
    }
}