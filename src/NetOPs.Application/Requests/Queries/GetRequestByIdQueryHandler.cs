using MediatR;
using NetOps.Application.Abstractions;
using NetOps.Application.Requests.DTOs;

namespace NetOps.Application.Requests.Queries
{
    public sealed class GetRequestByIdQueryHandler : IRequestHandler<GetRequestByIdQuery, ServiceRequestDto?>
    {
        private readonly IServiceRequestRepository _repository;

        public GetRequestByIdQueryHandler(IServiceRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceRequestDto ?> Handle(
            GetRequestByIdQuery request,
            CancellationToken cancellationToken)
        {
            var serviceRequest = await _repository.GetByIdAsync(
                request.Id,
                cancellationToken);

            return serviceRequest?.ToDto();
        }
    }
}