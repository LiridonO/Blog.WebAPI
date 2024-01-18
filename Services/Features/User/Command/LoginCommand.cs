using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs;
using Models.Models;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Features.Command;

public class LoginCommand : IRequest<DefaultResponse<string>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, DefaultResponse<string>>
{
    readonly IConfiguration _configuration;

    readonly UserManager<User> _userManger;

    readonly SignInManager<User> _signInManager;
    public LoginCommandHandler(IConfiguration configuration, UserManager<User> userManger, SignInManager<User> signInManager)
    {
        _configuration = configuration;
        _userManger = userManger;
        _signInManager = signInManager;
    }
    public async Task<DefaultResponse<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManger.FindByNameAsync(request.Email);

        if (user == null)
        {
            return new DefaultResponse<string>
            {
                Success = false,
                Message = "User not found"
            };
        }

        var result = await _userManger.CheckPasswordAsync(user, request.Password);

        if (!result)
        {
            return new DefaultResponse<string>
            {
                Success = false,
                Message = "Wrong credentials"
            };
        }

        var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);

        if (!signInResult.Succeeded)
        {
            return new DefaultResponse<string>
            {
                Success = false,
                Message = "Could not sing you in!"
            };
        }

        var claims = new[]
        {
            new Claim("Email", request.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim("FirstName", user.Name),
            new Claim("LastName", user.Lastname),
            new Claim("Id", user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

        var token = new JwtSecurityToken(issuer: _configuration["AuthSettings:Issuer"],
            audience: _configuration["AuthSettings:Audience"],
            claims: claims, expires: DateTime.Now.AddDays(30),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

        return new DefaultResponse<string>
        {
            Success = true,
            Message = tokenAsString
        };
    }
}