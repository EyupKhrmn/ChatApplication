using ChatApplication.API.CQRS.Login;
using ChatApplication.API.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace ChatApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(registerDto, cancellationToken));
        }
        
        [HttpGet("login")]
        public async Task<IActionResult> Login(LoginRequest request,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
    }
}
