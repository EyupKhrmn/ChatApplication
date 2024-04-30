using MediatR;

namespace ChatApplication.API.CQRS.Chats;

public sealed record ChatRequest : IRequest<ChatResponse>
{
    public Guid UserId { get; set; }
    public Guid ToUserId { get; set; }
}