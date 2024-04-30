using MediatR;

namespace ChatApplication.API.CQRS.Message;

public sealed record MessageRequest : IRequest<MessageResponse>
{
    public Guid UserId { get; set; }
    public Guid ToUserId { get; set; }
    public string Message { get; set; }
}