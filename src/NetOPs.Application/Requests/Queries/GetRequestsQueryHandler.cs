using MediatR;
using NetOps.Application.Abstractions;
using NetOps.Application.Requests.DTOs;

namespace NetOps.Application.Requests.Queries
{
    public sealed class GetRequestsQueryHandler
        : IRequestHandler<GetRequestsQuery, IReadOnlyList<ServiceRequestDto>>
    {
        private readonly IServiceRequestRepository _repository;

        public GetRequestsQueryHandler(
            IServiceRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<ServiceRequestDto>> Handle(
            GetRequestsQuery request,
            CancellationToken cancellationToken)
        {
            var requests = await _repository.GetAllAsync(
                cancellationToken);

            return requests
                .Select(request => request.ToDto())
                .ToList();
        }
    }
}
