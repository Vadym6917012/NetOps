using NetOps.Domain.Common;
using NetOps.Domain.Enums;
using NetOps.Domain.Exceptions;

namespace NetOps.Domain.Entities
{
    public class ServiceRequest : BaseEntity
    {
        public string Title { get; private set; } = null!;
        public string Description { get; private set; } = null!;

        public RequestStatus Status { get; private set; }
        public RequestPriority Priority { get; private set; }

        public Guid? TechnicianId { get; private set; }

        private ServiceRequest() { }

        public ServiceRequest(
            string title,
            string description,
            RequestPriority priority)
        {
            if ( string.IsNullOrWhiteSpace(title))
                throw new ArgumentException(
                     "Title cannot be null or empty.", nameof(title));

            if ( string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(
                    "Description cannot be null or empty.", nameof(description));

            Title = title;
            Description = description;
            Priority = priority;
            Status = RequestStatus.New;
        }

        public void AssignTo(Guid technicanId)
        {
            if ( Status != RequestStatus.New )
                throw new BusinessRuleException(
                    "Only new requests can be assigned to a technician.");

            TechnicianId = technicanId;
            Status = RequestStatus.Assigned;
        }

        public void StartWork()
        {
            if ( Status != RequestStatus.Assigned )
                throw new InvalidOperationException(
                    "Only assigned requests can be started.");

            Status = RequestStatus.InProgress;
        }

        public void Complete()
        {
            if ( Status != RequestStatus.InProgress )
                throw new InvalidOperationException(
                    "Only in-progress requests can be completed.");

            Status = RequestStatus.Completed;
        }

        public void Cancel()
        {
            if ( Status == RequestStatus.Completed )
                throw new InvalidOperationException(
                    "Complete requests cannot be cancelled.");

            Status = RequestStatus.Cancelled;
        }
    }
}