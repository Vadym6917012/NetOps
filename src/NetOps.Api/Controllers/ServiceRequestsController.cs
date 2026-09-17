using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetOps.Application.Requests.Commands;
using NetOps.Application.Requests.Queries;

namespace NetOps.Api.Controllers
{
    [ApiController]
    [Route("api/requests")]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly ISender _sender;

        public ServiceRequestsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateRequestCommand command,
            CancellationToken cancellationToken)
        {
            var request = await _sender.Send(
                command,
                cancellationToken);

            return CreatedAtAction(
                nameof(GetById),
                new { id = request.Id },
                request);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            CancellationToken cancellationToken)
        {
            var requests = await _sender.Send(
                new GetRequestsQuery(),
                cancellationToken);

            return Ok(requests);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(
            Guid id,
            CancellationToken cancellationToken)
        {
            var request = await _sender.Send(
                new GetRequestByIdQuery(id),
                cancellationToken);

            if ( request is null )
                return NotFound();

            return Ok(request);
        }
    }
}