using MediatR;
using Microsoft.AspNetCore.Mvc;
using HotelPMS.Application.Features.Guests.Commands.CreateGuest;
using HotelPMS.Application.Features.Guests.Commands.UpdateGuest;
using HotelPMS.Application.Features.Guests.Queries.GetGuests;
using HotelPMS.Application.Features.Guests.Queries.GetGuestBookingHistory;

namespace HotelPMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public GuestsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetGuestsQuery());
        return Ok(result);
    }

    [HttpGet("{id:guid}/booking-history")]
    public async Task<IActionResult> GetBookingHistory(Guid id)
    {
        var result = await _mediator.Send(new GetGuestBookingHistoryQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGuestCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { Id = id });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateGuestCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }
}