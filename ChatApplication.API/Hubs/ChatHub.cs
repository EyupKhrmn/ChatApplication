using ChatApplication.API.Context;
using ChatApplication.API.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.API.Hubs;

public sealed class ChatHub(ApplicationDbContext context) : Hub
{
    public static Dictionary<string, Guid> users = new();
    
    public async Task Connect(Guid userId)
    {
        users.Add(Context.ConnectionId,userId);
        User? user = await context.Users.FindAsync(userId);
        if (user is not null)
        {
            user.Status = "Online";
            await context.SaveChangesAsync();

            await Clients.All.SendAsync("Users", user);
        }
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        users.TryGetValue(Context.ConnectionId, out Guid userId);
        users.Remove(Context.ConnectionId);
        User? user = await context.Users.FindAsync(userId);
        if (user is not null)
        {
            user.Status = "Offline";
            await context.SaveChangesAsync();
            
            await Clients.All.SendAsync("Users", user);
        }
    }
}