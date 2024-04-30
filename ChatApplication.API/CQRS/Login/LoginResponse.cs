using ChatApplication.API.Models;

namespace ChatApplication.API.CQRS.Login;

public sealed record LoginResponse
{
    public string Message { get; set; }
    public User User { get; set; }
}