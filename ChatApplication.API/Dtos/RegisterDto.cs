namespace ChatApplication.API.Dtos;

public sealed record RegisterDto
{
    public string Name { get; set; } = string.Empty;
    public IFormFile Avatar { get; set; }
}