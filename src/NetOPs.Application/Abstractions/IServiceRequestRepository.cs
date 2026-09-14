using NetOps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
