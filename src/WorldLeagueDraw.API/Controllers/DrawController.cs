using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorldLeagueDraw.Application.Features.Draw.MakeDraw;

namespace WorldLeagueDraw.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrawController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DrawController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "make")]
        public async Task<MakeDrawCommandResponse> MakeDrawAsync([FromBody] MakeDrawCommand request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}