using NetOps.Domain.Enums;
using MediatR;

namespace NetOps.Application.Requests.Commands
{
    public sealed record CreateRequestCommand(
        string Title,
        string Description,
        RequestPriority Priority) : IRequest<Guid>;
}
