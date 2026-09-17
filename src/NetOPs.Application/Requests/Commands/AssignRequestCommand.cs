using MediatR;

namespace NetOps.Application.Requests.Commands
{
    public sealed record AssignRequestCommand(
        Guid RequestId,
        Guid TechnicianId
        ) : IRequest;
}
