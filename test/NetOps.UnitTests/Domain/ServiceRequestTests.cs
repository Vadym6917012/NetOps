using NetOps.Domain.Entities;
using NetOps.Domain.Enums;

namespace NetOps.UnitTests.Domain
{
    public class ServiceRequestTests
    {
        [Fact]
        public void New_Request_Should_Have_New_Status()
        {
            // Avarege
            var request = new ServiceRequest(
                "WI-FI problem",
                "Customer has unstable WI-FI conneection.",
                RequestPriority.High);

            // Assert
            Assert.Equal(RequestStatus.New, request.Status);
        }

        [Fact]
        public void Cannot_Complete_New_Request()
        {
            // Arrange
            var request = new ServiceRequest(
                "Wi-Fi problem",
                "Customer has unstable Wi-Fi connection.",
                RequestPriority.High);

            // Act
            var action = () => request.Complete();

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void Assigned_Request_Can_Be_Started()
        {
            // Arrange
            var request = new ServiceRequest(
                "Wi-Fi problem",
                "Customer has unstable Wi-Fi connection.",
                RequestPriority.High);

            var technicianId = Guid.NewGuid();

            // Act
            request.AssignTo(technicianId);
            request.StartWork();

            // Assert
            Assert.Equal(RequestStatus.InProgress, request.Status);
            Assert.Equal(technicianId, request.TechnicianId);
        }
    }
}