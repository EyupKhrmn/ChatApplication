using ChatApplication.API.Context;
using ChatApplication.API.Hubs;
using ChatApplication.API.Models;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.API.CQRS.Message;

public class MessageHandler(ApplicationDbContext context,IHubContext<ChatHub> _chatHubContext) : IRequestHandler<MessageRequest,MessageResponse>
{
    public async Task<MessageResponse> Handle(MessageRequest request, CancellationToken cancellationToken)
    {
        Chat chat = new()
        {
            UserId = request.UserId,
            ToUserId = request.ToUserId,
            Message = request.Message,
            Date = DateTime.Now
        };

        await context.AddAsync(chat,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        string connectionId = ChatHub.users.First(_=>_.Value == request.ToUserId).Key;

        await _chatHubContext.Clients.Client(connectionId).SendAsync("Messages",chat);

        return new MessageResponse();
    }
}