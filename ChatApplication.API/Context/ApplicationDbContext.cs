using ChatApplication.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.API.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Chat> Chats { get; set; }
}