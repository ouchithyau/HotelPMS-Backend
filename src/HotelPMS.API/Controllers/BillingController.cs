using HotelPMS.Application.Features.Billing.Commands.AddExtraService;
using HotelPMS.Application.Features.Billing.Commands.ApplyDiscount;
using HotelPMS.Application.Features.Billing.Commands.CheckInBooking;
using HotelPMS.Application.Features.Billing.Commands.CheckOutAndPay;
using HotelPMS.Application.Features.Billing.Commands.RecordPayment;
using HotelPMS.Application.Features.Billing.Queries.GetBookingFolioBill;
using HotelPMS.Application.Features.Billing.Queries.GetInvoice;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost("{bookingId}/payments")]
    [Authorize]
    public async Task<IActionResult> RecordPayment(Guid bookingId, [FromBody] RecordPaymentCommand command)
    {
        if (bookingId != command.BookingId)
        {
            return BadRequest("Booking ID mismatch.");
        }

        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Payment recorded successfully." });
    }

    [HttpPost("{bookingId}/discounts")]
    [Authorize(Roles = "Manager,Admin")]
    public async Task<IActionResult> ApplyDiscount(Guid bookingId, [FromBody] ApplyDiscountCommand command)
    {
        if (bookingId != command.BookingId)
        {
            return BadRequest("Booking ID mismatch.");
        }

        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Discount applied successfully." });
    }

    [HttpGet("{bookingId}/invoice")]
    [Authorize]
    public async Task<IActionResult> GetInvoice(Guid bookingId)
    {
        var result = await _mediator.Send(new GetInvoiceQuery(bookingId));
        if (result == null)
        {
            return NotFound("Invoice or Booking not found.");
        }

        return Ok(result);
    }
}