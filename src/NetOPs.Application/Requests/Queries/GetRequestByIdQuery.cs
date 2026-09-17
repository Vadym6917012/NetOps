using MediatR;
using NetOps.Application.Requests.DTOs;

namespace NetOps.Application.Requests.Queries
{
    public sealed record GetRequestByIdQuery(Guid Id)
        : IRequest<ServiceRequestDto?>;
}