using NetOps.Domain.Entities;

namespace NetOps.Application.Requests.DTOs
{
    public static class ServiceRequestMapping
    {
        public static ServiceRequestDto ToDto(
            this ServiceRequest request)
        {
            return new ServiceRequestDto(
                request.Id,
                request.Title,
                request.Description,
                request.Status,
                request.Priority,
                request.TechnicianId,
                request.CreatedAt
            );
        }
    }
}