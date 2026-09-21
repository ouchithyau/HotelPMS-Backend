using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HotelPMS.Application.Features.NightAudit.Commands.RunNightAudit;

namespace HotelPMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NightAuditController : ControllerBase
{
    private readonly IMediator _mediator;

    public NightAuditController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("run")]
    [Authorize(Roles = "Admin,NightAuditor,FinanceManager")]
    [Authorize(Policy = "CanRunNightAudit")]
    public async Task<IActionResult> RunNightAudit([FromBody] RunNightAuditCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = true, message = "Night audit successfully executed, revenue posted, and business date advanced.", data = result });
    }
}