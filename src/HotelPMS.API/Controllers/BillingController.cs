using MediatR;
using Microsoft.AspNetCore.Mvc;
using HotelPMS.Application.Features.Billing.Commands.CheckInBooking;
using HotelPMS.Application.Features.Billing.Commands.AddExtraService;
using HotelPMS.Application.Features.Billing.Commands.CheckOutAndPay;
using HotelPMS.Application.Features.Billing.Queries.GetBookingFolioBill;

namespace HotelPMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillingController : ControllerBase
{
    private readonly IMediator _mediator;

    public BillingController(IMediator mediator) => _mediator = mediator;

    [HttpPost("{bookingId:guid}/check-in")]
    public async Task<IActionResult> CheckIn(Guid bookingId)
    {
        await _mediator.Send(new CheckInBookingCommand(bookingId));
        return NoContent();
    }

    [HttpPost("extra-service")]
    public async Task<IActionResult> AddExtraService([FromBody] AddExtraServiceCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { BookingServiceId = id });
    }

    [HttpPost("{bookingId:guid}/check-out")]
    public async Task<IActionResult> CheckOutAndPay(Guid bookingId, [FromBody] CheckOutAndPayCommand command)
    {
        if (bookingId != command.BookingId) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("{bookingId:guid}/folio")]
    public async Task<IActionResult> GetFolioBill(Guid bookingId)
    {
        var result = await _mediator.Send(new GetBookingFolioBillQuery(bookingId));
        return Ok(result);
    }
}