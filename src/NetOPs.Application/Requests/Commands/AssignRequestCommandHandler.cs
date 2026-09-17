using MediatR;
using NetOps.Application.Abstractions;
using NetOps.Application.Exceptions;

namespace NetOps.Application.Requests.Commands
{
    public sealed class AssignRequestCommandHandler
        : IRequestHandler<AssignRequestCommand>
    {
        private readonly IServiceRequestRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AssignRequestCommandHandler(
            IServiceRequestRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(
            AssignRequestCommand request,
            CancellationToken cancellationToken)
        {
            var serviceRequest = await _repository.GetByIdAsync(
                request.RequestId,
                cancellationToken);

            if (serviceRequest is null)
                throw new NotFoundException(
                    $"Service request `{request.RequestId}` was not found.");

            serviceRequest.AssignTo(request.TechnicianId);

            await _unitOfWork.SaveChangesAsync(
                cancellationToken);
        }
    }
}
