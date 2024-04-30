namespace ChatApplication.API.Models;

public sealed class User
{
    public User()
    {
        UserId = Guid.NewGuid();
    }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}