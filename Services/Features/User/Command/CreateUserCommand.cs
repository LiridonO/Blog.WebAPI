using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Models.DTOs;
using Models.Enums;
using Models.Models;
using Services.Features.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services.Features.Command;
public class CreateUserCommand : IRequest<DefaultResponse<bool>>
{
    public CreateUserDTO UserCreateRequest { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, DefaultResponse<bool>>
{
    readonly UserManager<User> _userManger;

    public CreateUserCommandHandler(UserManager<User> userManger)
    {
        _userManger = userManger;
    }

    public async Task<DefaultResponse<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = new User
            {
                UserName = request.UserCreateRequest.UserName,
                Email = request.UserCreateRequest.Email,
                Name = request.UserCreateRequest.Name,
                Lastname = request.UserCreateRequest.Lastname,
                Birthdate = request.UserCreateRequest.Birthdate,
                Gender = request.UserCreateRequest.Gender
            };
            var result = await _userManger.CreateAsync(user, request.UserCreateRequest.Password);

            if (!result.Succeeded)
            {
                return new DefaultResponse<bool>
                {
                    Success = false,
                    Errors = result.Errors.Select(x => x.Description).ToList()
                };
            }

            return new DefaultResponse<bool>
            {
                Success = true,
                Data = true
            };
        }
        catch (Exception ex)
        {
            return new DefaultResponse<bool>
            {
                Success = false,
                Message = ex.Message
            };
        }
    }
}
