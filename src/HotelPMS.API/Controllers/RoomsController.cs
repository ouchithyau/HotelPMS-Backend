using MediatR;
using Microsoft.AspNetCore.Mvc;
using HotelPMS.Application.Features.Rooms.Commands.CreateRoom;
using HotelPMS.Application.Features.Rooms.Commands.UpdateRoomStatus;
using HotelPMS.Application.Features.Rooms.Queries.GetRooms;
using HotelPMS.Application.Features.Rooms.Queries.GetRoomById;

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
}