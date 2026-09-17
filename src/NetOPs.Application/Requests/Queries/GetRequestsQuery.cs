using MediatR;
using NetOps.Application.Requests.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetOps.Application.Requests.Queries
{
    public sealed record GetRequestsQuery 
        : IRequest<IReadOnlyList<ServiceRequestDto>>;
}
