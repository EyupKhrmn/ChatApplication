using ChatApplication.API.Context;
using ChatApplication.API.Models;
using ChatApplication.API.Response;
using GenericFileService.Files;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.API.CQRS.Register;

public class RegisterCommandHandler(ApplicationDbContext context) : IRequestHandler<RegisterRequest,RegisterResponse>
{
    public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        bool isNameExist = await context.Users.AnyAsync(_ => _.Name == request.RegisterDto.Name);
        if (request.RegisterDto.Name is null || request.RegisterDto.Avatar is null || isNameExist)
        {
            return new RegisterResponse
            {
                Result = new Result
                {
                    Message = "Name and Avatar are required and Name must be unique",
                    IsSuccess = false
                }
            };
        }

        string avatar = FileService.FileSaveToServer(request.RegisterDto.Avatar,"wwwroot/avatars");

        var user = new User
        {
            Name = request.RegisterDto.Name,
            Avatar = avatar
        };

        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new RegisterResponse
        {
            Result = new Result
            {
                IsSuccess = true,
                Message = "User registered successfully"
            }
        };

    }
}