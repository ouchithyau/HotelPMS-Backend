using HotelPMS.Application.Features.Reservations.Commands.AddSpecialRequests;
using HotelPMS.Application.Features.Reservations.Commands.CancelBooking;
using HotelPMS.Application.Features.Reservations.Commands.CancelWithRefund;
using HotelPMS.Application.Features.Reservations.Commands.CheckIn;
using HotelPMS.Application.Features.Reservations.Commands.CheckOut;
using HotelPMS.Application.Features.Reservations.Commands.CreateBooking;
using HotelPMS.Application.Features.Reservations.Commands.ExtendStay;
using HotelPMS.Application.Features.Reservations.Commands.Folio;
using HotelPMS.Application.Features.Reservations.Commands.ModifyBooking;
using HotelPMS.Application.Features.Reservations.Commands.NoShow;
using HotelPMS.Application.Features.Reservations.Commands.PreAuth;
using HotelPMS.Application.Features.Reservations.Commands.TransferRoom;
using HotelPMS.Application.Features.Reservations.Commands.WalkIn;
using HotelPMS.Application.Features.Reservations.Queries.CheckAvailability;
using HotelPMS.Application.Features.Reservations.Queries.GetAvailability;
using HotelPMS.Application.Features.Reservations.Queries.GetBookingById;
using HotelPMS.Application.Features.Reservations.Queries.GetBookingsByDateRange;
using HotelPMS.Application.Features.Reservations.Queries.GetInvoice;
using HotelPMS.Application.Features.Reservations.Queries.NightAudit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("check-availability")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAvailability([FromQuery] DateTime checkIn, [FromQuery] DateTime checkOut)
    {
        var result = await _mediator.Send(new GetRoomAvailabilityQuery(checkIn, checkOut));
        return Ok(result);
    }

    [HttpPost("{id}/special-requests")]
    [Authorize]
    public async Task<IActionResult> AddSpecialRequests(Guid id, [FromBody] string specialRequests)
    {
        var result = await _mediator.Send(new AddSpecialRequestsCommand(id, specialRequests));
        return Ok(new { success = result, message = "Special requests added successfully." });
    }

    [HttpPost("{id}/check-in")]
    [Authorize(Roles = "Admin,Manager,Receptionist")]
    public async Task<IActionResult> CheckIn(Guid id)
    {
        var result = await _mediator.Send(new CheckInReservationCommand(id));
        return Ok(new { success = result, message = "Guest checked in successfully and room status updated to Occupied." });
    }

    [HttpPost("walk-in")]
    [Authorize(Roles = "Admin,Manager,Receptionist")]
    public async Task<IActionResult> WalkInRegistration([FromBody] WalkInRegistrationCommand command)
    {
        var reservationId = await _mediator.Send(command);
        return Ok(new { success = true, reservationId, message = "Walk-in guest registered and checked in successfully." });
    }

    [HttpPost("{id}/pre-auth-card")]
    [Authorize(Roles = "Admin,Manager,Receptionist")]
    public async Task<IActionResult> PreAuthorizeCard(Guid id, [FromBody] PreAuthorizeCardCommand command)
    {
        // Ensure route id matches command if needed, or pass fields via body/route
        var result = await _mediator.Send(command with { ReservationId = id });
        return Ok(new { success = result, message = "Credit card pre-authorization successful and deposit secured." });
    }

    [HttpPost("{id}/transfer-room")]
    [Authorize(Roles = "Admin,Manager,Receptionist")]
    public async Task<IActionResult> TransferRoom(Guid id, [FromBody] Guid newRoomId)
    {
        var result = await _mediator.Send(new TransferRoomCommand(id, newRoomId));
        return Ok(new { success = result, message = "Room transferred successfully. Old room set to cleaning, new room set to occupied." });
    }

    [HttpPost("{id}/extend-stay")]
    [Authorize(Roles = "Admin,Manager,Receptionist")]
    public async Task<IActionResult> ExtendStay(Guid id, [FromBody] DateTime newCheckOutDate)
    {
        var result = await _mediator.Send(new ExtendStayCommand(id, newCheckOutDate));
        return Ok(new { success = result, message = "Stay extended successfully with updated checkout date." });
    }

    [HttpPost("{id}/folio-charges")]
    [Authorize]
    public async Task<IActionResult> AddFolioCharge(Guid id, [FromBody] AddFolioChargeCommand command)
    {
        var result = await _mediator.Send(command with { ReservationId = id });
        return Ok(new { success = result, message = "Service charge added to guest room folio successfully." });
    }

    [HttpGet("{id}/final-invoice")]
    [Authorize]
    public async Task<IActionResult> GetFinalInvoice(Guid id)
    {
        var result = await _mediator.Send(new GetFinalInvoiceQuery(id));
        if (result == null) return NotFound("Invoice could not be generated for this reservation.");
        return Ok(result);
    }

    [HttpPost("{id}/check-out")]
    [Authorize(Roles = "Admin,Manager,Receptionist")]
    public async Task<IActionResult> CheckOut(Guid id)
    {
        var result = await _mediator.Send(new CheckOutReservationCommand(id));
        return Ok(new { success = result, message = "Guest checked out successfully. Room status updated to Dirty and housekeeping task generated." });
    }
    [HttpPost("{id}/cancel-with-refund")]
    [Authorize(Roles = "Admin,Manager,Receptionist")]
    public async Task<IActionResult> CancelWithRefund(Guid id, [FromBody] string reason)
    {
        var result = await _mediator.Send(new CancelReservationWithRefundCommand(id, reason));
        return Ok(new { success = result, message = "Reservation cancelled successfully, penalty calculated, and refund processed." });
    }

    [HttpPost("{id}/no-show")]
    [Authorize(Roles = "Admin,Manager,Receptionist")]
    public async Task<IActionResult> MarkNoShow(Guid id)
    {
        var result = await _mediator.Send(new MarkNoShowCommand(id));
        return Ok(new { success = result, message = "Reservation marked as No-Show, first-night retention applied, and room released." });
    }

    [HttpGet("night-audit-report")]
    [Authorize(Roles = "Admin,NightAuditor,Manager")]
    public async Task<IActionResult> GetNightAuditReport([FromQuery] DateTime auditDate)
    {
        var result = await _mediator.Send(new GetNightAuditReportQuery(auditDate));
        return Ok(result);
    }
}