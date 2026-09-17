using MediatR;

namespace NetOps.Application.Requests.Commands
{
    public sealed record StartRequestCommand(
        Guid RequestId
        ) : IRequest;
}
