using MediatR;
using Microsoft.AspNetCore.Mvc;
using HotelPMS.Application.Features.RoomTypes.Commands.CreateRoomType;
using HotelPMS.Application.Features.RoomTypes.Commands.UpdateRoomType;
using HotelPMS.Application.Features.RoomTypes.Queries.GetRoomTypes;

namespace HotelPMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoomTypesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetRoomTypesQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoomTypeCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id }, id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRoomTypeCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }
}