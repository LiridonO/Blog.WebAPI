using MediatR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Commands;
using Services.Features.Command;
using Services.Features.DTO;

namespace Blog.WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<DefaultResponse<bool>> CreateUser(CreateUserDTO createUserDTO)
    {
        var result = await _mediator.Send(new CreateUserCommand() { UserCreateRequest = createUserDTO });

        return result;
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<DefaultResponse<bool>> DeleteUser(Guid id)
    {
        var result = await _mediator.Send(new DeleteUserCommand() { Id = id });

        return result;
    }
}
