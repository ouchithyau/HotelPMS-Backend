using HotelPMS.Application.Features.Auth.Commands.ChangePassword;
using HotelPMS.Application.Features.Auth.Commands.Enable2FA;
using HotelPMS.Application.Features.Auth.Commands.ForgotPassword;
using HotelPMS.Application.Features.Auth.Commands.Login;
using HotelPMS.Application.Features.Auth.Commands.Logout;
using HotelPMS.Application.Features.Auth.Commands.RefreshToken;
using HotelPMS.Application.Features.Auth.Commands.Register;
using HotelPMS.Application.Features.Auth.Commands.ResetPassword;
using HotelPMS.Application.Features.Auth.Commands.RevokeToken;
using HotelPMS.Application.Features.Auth.Commands.Verify2FA;
using HotelPMS.Application.Features.Auth.Queries.GetAuditLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout([FromBody] LogoutCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { message = "Logged out successfully" });
    }

    [HttpPost("change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { message = "Password changed successfully" });
    }

    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Password reset instructions sent if email exists." });
    }

    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Password has been successfully reset." });
    }

    [HttpPost("revoke-token")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Staff session token revoked successfully." });
    }

    [HttpPost("2fa/enable")]
    [Authorize]
    public async Task<IActionResult> Enable2FA([FromBody] Enable2FACommand command)
    {
        var secret = await _mediator.Send(command);
        return Ok(new { success = true, secretKey = secret, message = "2FA secret generated. Please verify to activate." });
    }

    [HttpPost("2fa/verify")]
    [Authorize]
    public async Task<IActionResult> Verify2FA([FromBody] Verify2FACommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = result ? "2FA verified and enabled successfully." : "Invalid verification code." });
    }

    [HttpGet("audit-logs")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> GetStaffAuditLogs([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        var result = await _mediator.Send(new GetStaffAuditLogsQuery(startDate, endDate));
        return Ok(result);
    }
}