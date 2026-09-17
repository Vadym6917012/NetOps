using System;
using System.Collections.Generic;
using System.Text;

namespace NetOps.Application.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken);
    }
}
