using MediatR;

namespace ChatApplication.API.CQRS.Login;

public sealed record LoginRequest : IRequest<LoginResponse>
{
    public string Name { get; set; }
}