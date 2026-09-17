using MediatR;
using NetOps.Application.Abstractions;
using NetOps.Application.Requests.DTOs;
using NetOps.Domain.Entities;

namespace NetOps.Application.Requests.Commands
{
    public sealed class CreateRequestCommandHandler
        : IRequestHandler<CreateRequestCommand, ServiceRequestDto>
    {
        private readonly IServiceRequestRepository _repository;

        public CreateRequestCommandHandler(
            IServiceRequestRepository repository)
        {
            _repository = repository;

        }
        public async Task<ServiceRequestDto> Handle(
            CreateRequestCommand request,
            CancellationToken cancellationToken)
        {
            var serviceRequest = new ServiceRequest(
                request.Title,
                request.Description,
                request.Priority);

            await _repository.AddAsync(
                serviceRequest,
                cancellationToken);

            return serviceRequest.ToDto();
        }
    }
}