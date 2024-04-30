using ChatApplication.API.Context;
using ChatApplication.API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.API.CQRS.Chats;

public sealed class ChatHandler(ApplicationDbContext context) : IRequestHandler<ChatRequest,ChatResponse>
{
    public async Task<ChatResponse> Handle(ChatRequest request, CancellationToken cancellationToken)
    {
        List<Chat> chats = await 
            context
            .Chats
            .Where(_ => _.UserId == request.UserId 
                        || _.UserId == request.ToUserId &&
            _.UserId == request.ToUserId
                        || _.UserId == request.UserId)
            .OrderBy(_=>_.Date).ToListAsync(cancellationToken);

        return new ChatResponse();
    }
}