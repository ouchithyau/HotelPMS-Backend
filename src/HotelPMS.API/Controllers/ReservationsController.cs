using MediatR;
using Microsoft.AspNetCore.Mvc;
using HotelPMS.Application.Features.Reservations.Commands.CreateBooking;
using HotelPMS.Application.Features.Reservations.Commands.ModifyBooking;
using HotelPMS.Application.Features.Reservations.Commands.CancelBooking;
using HotelPMS.Application.Features.Reservations.Queries.CheckAvailability;
using HotelPMS.Application.Features.Reservations.Queries.GetBookingById;
using HotelPMS.Application.Features.Reservations.Queries.GetBookingsByDateRange;

namespace HotelPMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationsController(IMediator mediator) => _mediator = mediator;

    [HttpGet("availability")]
    public async Task<IActionResult> CheckAvailability([FromQuery] DateTime checkIn, [FromQuery] DateTime checkOut)
    {
        var result = await _mediator.Send(new CheckAvailabilityQuery(checkIn, checkOut));
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetBookingByIdQuery(id));
        return Ok(result);
    }

    [HttpGet("date-range")]
    public async Task<IActionResult> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var result = await _mediator.Send(new GetBookingsByDateRangeQuery(startDate, endDate));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Modify(Guid id, [FromBody] ModifyBookingCommand command)
    {
        if (id != command.BookingId) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel(Guid id)
    {
        await _mediator.Send(new CancelBookingCommand(id));
        return NoContent();
    }
}