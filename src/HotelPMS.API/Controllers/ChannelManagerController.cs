using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HotelPMS.Application.DTOs;
using HotelPMS.Application.Features.ChannelManager.Commands.SyncOtaBooking;

namespace HotelPMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChannelManagerController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChannelManagerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("webhook/booking-sync")]
    [AllowAnonymous] // Usually secured via webhook secret tokens or API keys from OTAs
    public async Task<IActionResult> SyncOtaBooking([FromBody] OtaBookingSyncDto bookingDto)
    {
        var command = new SyncOtaBookingCommand(bookingDto);
        var result = await _mediator.Send(command);
        return Ok(new { success = result, message = "OTA reservation successfully synchronized and inventory updated to prevent overbooking." });
    }
} 