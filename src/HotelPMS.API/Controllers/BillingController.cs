using HotelPMS.Application.DTOs;
using HotelPMS.Application.Features.Billing.Commands.AddExtraService;
using HotelPMS.Application.Features.Billing.Commands.AdjustCharge;
using HotelPMS.Application.Features.Billing.Commands.ApplyDiscount;
using HotelPMS.Application.Features.Billing.Commands.CheckInBooking;
using HotelPMS.Application.Features.Billing.Commands.CheckOutAndPay;
using HotelPMS.Application.Features.Billing.Commands.CityLedger;
using HotelPMS.Application.Features.Billing.Commands.Payment;
using HotelPMS.Application.Features.Billing.Commands.PosCharge;
using HotelPMS.Application.Features.Billing.Commands.RecordPayment;
using HotelPMS.Application.Features.Billing.Commands.Refund;
using HotelPMS.Application.Features.Billing.Commands.SplitFolio;
using HotelPMS.Application.Features.Billing.Commands.TransferCharge;
using HotelPMS.Application.Features.Billing.Queries.GetBookingFolioBill;
using HotelPMS.Application.Features.Billing.Queries.GetDailyRevenue;
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
    [HttpPost("{bookingId}/split-folio")]
    [Authorize(Roles = "Admin,Manager,Cashier")]
    public async Task<IActionResult> SplitFolio(Guid bookingId, [FromBody] SplitFolioCommand command)
    {
        var result = await _mediator.Send(command with { ReservationId = bookingId });
        return Ok(new { success = result, message = "Folio charge successfully split into target folio." });
    }
    [HttpPost("{bookingId}/transfer-charge")]
    [Authorize(Roles = "Admin,Manager,Cashier")]
    public async Task<IActionResult> TransferCharge(Guid bookingId, [FromBody] TransferChargeCommand command)
    {
        var result = await _mediator.Send(command with { SourceReservationId = bookingId });
        return Ok(new { success = result, message = "Charge successfully transferred to target room folio." });
    }
    [HttpPost("{bookingId}/adjustments")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> AdjustCharge(Guid bookingId, [FromBody] AdjustChargeCommand command)
    {
        var result = await _mediator.Send(command with { ReservationId = bookingId });
        return Ok(new { success = result, message = "Charge successfully adjusted/waived off under manager authorization." });
    }
    [HttpPost("{bookingId}/city-ledger")]
    [Authorize(Roles = "Admin,Manager,Finance")]
    public async Task<IActionResult> TransferToCityLedger(Guid bookingId, [FromBody] TransferToCityLedgerCommand command)
    {
        var result = await _mediator.Send(command with { ReservationId = bookingId });
        return Ok(new { success = result, message = "Folio balance successfully transferred to City Ledger (AR) for corporate billing." });
    }
    [HttpPost("{bookingId}/refund")]
    [Authorize(Roles = "Admin,Manager,Cashier")]
    public async Task<IActionResult> ProcessRefund(Guid bookingId, [FromBody] ProcessRefundCommand command)
    {
        var result = await _mediator.Send(command with { ReservationId = bookingId });
        return Ok(new { success = result, message = "Refund processed successfully and recorded in financial audit log." });
    }
    [HttpGet("daily-revenue-summary")]
    [Authorize(Roles = "Admin,Manager,NightAuditor,Finance")]
    public async Task<IActionResult> GetDailyRevenueSummary([FromQuery] DateTime businessDate)
    {
        var result = await _mediator.Send(new GetDailyRevenueSummaryQuery(businessDate));
        return Ok(result);
    }
    [HttpPost("pos-charge")]
    [Authorize(Roles = "Admin,Cashier,RestaurantManager,FrontOfficeManager")]
    public async Task<IActionResult> PostPosCharge([FromBody] PosChargeSyncDto chargeDto)
    {
        var command = new PostPosChargeToFolioCommand(chargeDto);
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "POS outlet charge successfully posted to guest room folio." });
    }

    [HttpPost("process-card-payment")]
    [Authorize(Roles = "Admin,Cashier,FinanceManager")]
    public async Task<IActionResult> ProcessCardPayment([FromBody] TokenizedPaymentDto paymentDto)
    {
        var command = new ProcessTokenizedPaymentCommand(paymentDto);
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "Tokenized credit card payment processed successfully via payment gateway." });
    }
}