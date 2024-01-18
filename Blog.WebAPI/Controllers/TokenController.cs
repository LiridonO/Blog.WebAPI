using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Features.Command;

namespace Blog.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenController : Controller
{
    readonly IMediator _mediator;

    public TokenController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Login")]
    public async Task<DefaultResponse<string>> Login(LoginCommand loginCommand)
    {
        var result = await _mediator.Send(loginCommand);
        return result;
    }
}
