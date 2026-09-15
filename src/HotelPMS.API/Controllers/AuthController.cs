using MediatR;
using Microsoft.AspNetCore.Mvc;
using HotelPMS.Application.Features.Auth.Commands.Register;
using HotelPMS.Application.Features.Auth.Commands.Login;

namespace HotelPMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator) => _mediator = mediator;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(new { UserId = userId });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(new { Token = token });
    }
}