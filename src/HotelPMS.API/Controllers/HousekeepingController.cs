using HotelPMS.Application.Features.Housekeeping.Commands.AssignTask;
using HotelPMS.Application.Features.Housekeeping.Commands.ReportIssue;
using HotelPMS.Application.Features.Housekeeping.Commands.UpdateCleaningStatus;
using HotelPMS.Application.Features.Housekeeping.Queries.GetHousekeepingList;
using HotelPMS.Application.Features.Housekeeping.Queries.GetRoomStatus;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelPMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousekeepingController : ControllerBase
{
    private readonly IMediator _mediator;

    public HousekeepingController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await _mediator.Send(new GetHousekeepingListQuery());
        return Ok(result);
    }

    [HttpPut("status")]
    public async Task<IActionResult> UpdateStatus([FromBody] UpdateCleaningStatusCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("assign")]
    [Authorize(Roles = "Manager,HousekeepingSupervisor")]
    public async Task<IActionResult> AssignTask([FromBody] AssignHousekeepingTaskCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Housekeeping task assigned successfully." });
    }

    [HttpGet("room/{roomId}")]
    [Authorize]
    public async Task<IActionResult> GetRoomStatus(Guid roomId)
    {
        var result = await _mediator.Send(new GetRoomHousekeepingQuery(roomId));
        if (result == null) return NotFound("Housekeeping record not found for this room.");
        return Ok(result);
    }

    [HttpPost("report-issue")]
    [Authorize]
    public async Task<IActionResult> ReportMaintenanceIssue([FromBody] ReportMaintenanceIssueCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Maintenance issue reported successfully." });
    }
}