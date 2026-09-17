using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetOps.Application.Requests.Commands
{
    public sealed record AssignRequestCommand(
        Guid RequestId,
        Guid TechnicianId
        ) : IRequest;
}
