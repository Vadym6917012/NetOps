using MediatR;
using NetOps.Application.Abstractions;
using NetOps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetOps.Application.Requests.Commands
{
    public sealed class CreateRequestCommandHandler
        : IRequestHandler<CreateRequestCommand, Guid>
    {
        private readonly IServiceRequestRepository _repository;

        public CreateRequestCommandHandler(
            IServiceRequestRepository repository)
        {
            _repository = repository;
        
        }
        public async Task<Guid> Handle(
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

            return serviceRequest.Id;
        }
    }
}
