using NetOps.Domain.Enums;

namespace NetOps.Application.Requests.DTOs
{
    public sealed record ServiceRequestDto
    (
        Guid Id,
        string Title,
        string Description,
        RequestStatus Status,
        RequestPriority Priority,
        Guid? TechnicianId,
        DateTime CreatedAt
    );
}