using ChatApplication.API.Dtos;
using ChatApplication.API.Response;
using MediatR;

namespace ChatApplication.API.CQRS.Register;

public abstract class RegisterRequest : IRequest<RegisterResponse>
{
    public RegisterDto RegisterDto { get; set; }
}