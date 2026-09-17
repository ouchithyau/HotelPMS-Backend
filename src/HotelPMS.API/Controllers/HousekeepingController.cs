using HotelPMS.Application.Features.Housekeeping.Commands.AllocateTask;
using HotelPMS.Application.Features.Housekeeping.Commands.AssignTask;
using HotelPMS.Application.Features.Housekeeping.Commands.DeepCleaning;
using HotelPMS.Application.Features.Housekeeping.Commands.InspectRoom;
using HotelPMS.Application.Features.Housekeeping.Commands.LostAndFound;
using HotelPMS.Application.Features.Housekeeping.Commands.Minibar;
using HotelPMS.Application.Features.Housekeeping.Commands.ReportIssue;
using HotelPMS.Application.Features.Housekeeping.Commands.UpdateCleaningStatus;
using HotelPMS.Application.Features.Housekeeping.Queries.GetHousekeepingList;
using HotelPMS.Application.Features.Housekeeping.Queries.GetRoomStatus;
using HotelPMS.Application.Features.Housekeeping.Queries.GetWorkload;
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
    [HttpPost("room-inspection")]
    [Authorize(Roles = "Admin,HousekeepingSupervisor,Manager")]
    public async Task<IActionResult> InspectRoom([FromBody] InspectRoomCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Room inspection completed and status updated to Inspected (Ready)." });
    }
    [HttpPost("lost-and-found")]
    [Authorize(Roles = "Admin,HousekeepingSupervisor,FrontOfficeManager")]
    public async Task<IActionResult> RegisterLostAndFound([FromBody] RegisterLostAndFoundCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Lost and found item successfully registered and secured." });
    }
    [HttpPost("minibar-consumption")]
    [Authorize(Roles = "Admin,HousekeepingStaff,HousekeepingSupervisor")]
    public async Task<IActionResult> ReportMinibarConsumption([FromBody] ReportMinibarConsumptionCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Minibar consumption successfully recorded and charged to guest folio." });
    }
    [HttpPost("deep-cleaning-schedule")]
    [Authorize(Roles = "Admin,HousekeepingManager,MaintenanceManager")]
    public async Task<IActionResult> ScheduleDeepCleaning([FromBody] ScheduleDeepCleaningCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Room successfully scheduled for deep cleaning and blocked from reservations." });
    }
    [HttpPost("allocate-tasks")]
    [Authorize(Roles = "Admin,HousekeepingSupervisor,HousekeepingManager")]
    public async Task<IActionResult> AllocateTasks([FromBody] AllocateHousekeepingTaskCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Housekeeping tasks successfully allocated to staff." });
    }

    [HttpGet("staff-workload/{staffId}")]
    [Authorize(Roles = "Admin,HousekeepingSupervisor,HousekeepingManager")]
    public async Task<IActionResult> GetStaffWorkload(string staffId, [FromQuery] DateTime date)
    {
        var result = await _mediator.Send(new GetStaffWorkloadQuery(staffId, date));
        return Ok(result);
    }
}