using ChatApplication.API.Context;
using ChatApplication.API.Models;
using ChatApplication.API.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.API.CQRS.Login;

public class LoginHandler(ApplicationDbContext context) : IRequestHandler<LoginRequest,LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        User? user = await context.Users.FirstOrDefaultAsync(_ => _.Name == request.Name, cancellationToken: cancellationToken);

        if (user is null) return new LoginResponse { Message = "Giriş Başarısız",User = null};

        user.Status = "Online";
        await context.SaveChangesAsync(cancellationToken);
        
        return new LoginResponse
        {
            Message = "Giriş Başarılı",
            User = user
        };
    }
}