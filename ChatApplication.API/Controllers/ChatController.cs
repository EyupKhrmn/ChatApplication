using ChatApplication.API.CQRS.Chats;
using ChatApplication.API.CQRS.Message;
using ChatApplication.API.Hubs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("GetChats")]
        public async Task<IActionResult> GetChats(ChatRequest request,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(MessageRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
    }
}
