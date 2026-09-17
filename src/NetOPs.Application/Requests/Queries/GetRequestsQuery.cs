using MediatR;
using NetOps.Application.Requests.DTOs;

namespace NetOps.Application.Requests.Queries
{
    public sealed record GetRequestsQuery
        : IRequest<IReadOnlyList<ServiceRequestDto>>;
}
