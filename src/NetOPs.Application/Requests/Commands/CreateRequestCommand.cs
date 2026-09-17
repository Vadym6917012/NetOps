using MediatR;
using NetOps.Application.Requests.DTOs;
using NetOps.Domain.Enums;

namespace NetOps.Application.Requests.Commands
{
    public sealed record CreateRequestCommand(
        string Title,
        string Description,
        RequestPriority Priority
        ) : IRequest<ServiceRequestDto>;
}