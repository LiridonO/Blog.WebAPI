using MediatR;
using Microsoft.AspNetCore.Identity;
using Models.DTOs;
using Models.Models;

namespace Services.Features.Command;

public class DeleteUserCommand : IRequest<DefaultResponse<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DefaultResponse<bool>>
{
    readonly UserManager<User> _userManager;

    public DeleteUserCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<DefaultResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString());

        if (user is null)
        {
            return new DefaultResponse<bool>
            {
                Data = false,
                Message = "User not found"
            };
        }

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            return new DefaultResponse<bool>
            {
                Success = false,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        return new DefaultResponse<bool>
        {
            Success = true,
            Data = true
        };
    }
}