using HotelPMS.Application.Features.Rooms.Commands.Amenities;
using HotelPMS.Application.Features.Rooms.Commands.BlockRoom;
using HotelPMS.Application.Features.Rooms.Commands.CreateRoom;
using HotelPMS.Application.Features.Rooms.Commands.RoomMove;
using HotelPMS.Application.Features.Rooms.Commands.UpdateRoomStatus;
using HotelPMS.Application.Features.Rooms.Queries.GetAvailabilityMatrix;
using HotelPMS.Application.Features.Rooms.Queries.GetFloorStatusBoard;
using HotelPMS.Application.Features.Rooms.Queries.GetRoomById;
using HotelPMS.Application.Features.Rooms.Queries.GetRooms;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelPMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoomsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetRoomsQuery());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetRoomByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoomCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPatch("{id:guid}/status")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateRoomStatusCommand command)
    {
        if (id != command.RoomId) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpPost("{id}/block")]
    [Authorize(Roles = "Admin,MaintenanceManager,FrontOfficeManager")]
    public async Task<IActionResult> BlockRoom(Guid id, [FromBody] BlockRoomCommand command)
    {
        var result = await _mediator.Send(command with { RoomId = id });
        return Ok(new { success = result, message = "Room successfully blocked as Out of Order (OOO)." });
    }
    [HttpPost("room-move")]
    [Authorize(Roles = "Admin,FrontOfficeManager,Receptionist")]
    public async Task<IActionResult> MoveRoom([FromBody] RoomMoveCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Guest successfully moved to the new room, and folio mappings updated." });
    }
    [HttpGet("availability-matrix")]
    [Authorize(Roles = "Admin,FrontOfficeManager,ReservationAgent,Receptionist")]
    public async Task<IActionResult> GetAvailabilityMatrix([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var result = await _mediator.Send(new GetRoomAvailabilityMatrixQuery(startDate, endDate));
        return Ok(result);
    }
    [HttpPost("{id}/amenities")]
    [Authorize(Roles = "Admin,FrontOfficeManager,RoomMaster")]
    public async Task<IActionResult> AssignRoomAmenities(Guid id, [FromBody] AssignRoomAmenitiesCommand command)
    {
        var result = await _mediator.Send(command with { RoomId = id });
        return Ok(new { success = result, message = "Room amenities and tags successfully updated." });
    }
    [HttpGet("floor-status-board")]
    [Authorize(Roles = "Admin,FrontOfficeManager,HousekeepingSupervisor,Receptionist")]
    public async Task<IActionResult> GetFloorStatusBoard()
    {
        var result = await _mediator.Send(new GetFloorStatusBoardQuery());
        return Ok(result);
    }
}