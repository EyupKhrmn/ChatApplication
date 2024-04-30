namespace ChatApplication.API.Models;

public sealed class Chat
{
    public Chat()
    {
        ChatId = Guid.NewGuid();
    }
    public Guid ChatId { get; set; }
    public Guid UserId { get; set; }
    public Guid ToUserId { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}