using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Repositories.Context;
using Services.Features.DTO;

namespace Services.Features.Query;

public class GetUserByIdQuery : IRequest<DefaultResponse<UserDTO>>
{
    public Guid Id { get; set; }

}

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, DefaultResponse<UserDTO>>
{
    readonly ApplicationDbContext _applicationDbContext;

    public GetUserByIdQueryHandler(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<DefaultResponse<UserDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _applicationDbContext
            .Users
            .Where(u => u.Id == request.Id)
            .FirstOrDefaultAsync();

        if (user is null)
        {
            return new DefaultResponse<UserDTO>
            {
                Success = false,
                Message = "User not found"
            };
        }

        var userDto = new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            LastName = user.Lastname,
            PhoneNumber = user.PhoneNumber
        };

        return new DefaultResponse<UserDTO>
        {
            Success = true,
            Data = userDto
        };
    }
}