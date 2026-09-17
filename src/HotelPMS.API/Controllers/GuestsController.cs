using HotelPMS.Application.Features.Guests.Commands.AddPreference;
using HotelPMS.Application.Features.Guests.Commands.BlacklistGuest;
using HotelPMS.Application.Features.Guests.Commands.CreateGuest;
using HotelPMS.Application.Features.Guests.Commands.DeleteGuest;
using HotelPMS.Application.Features.Guests.Commands.UpdateGuest;
using HotelPMS.Application.Features.Guests.Commands.UpdateLoyalty;
using HotelPMS.Application.Features.Guests.Commands.VerifyDocument;
using HotelPMS.Application.Features.Guests.Queries.GetActiveStay;
using HotelPMS.Application.Features.Guests.Queries.GetGuestBookingHistory;
using HotelPMS.Application.Features.Guests.Queries.GetGuests;
using HotelPMS.Application.Features.Guests.Queries.GetLoyalty;
using HotelPMS.Application.Features.Guests.Queries.GetSpendAnalytics;
using HotelPMS.Application.Features.Guests.Queries.SearchGuests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("search")]
    [Authorize]
    public async Task<IActionResult> SearchGuests([FromQuery] string searchTerm)
    {
        var result = await _mediator.Send(new SearchGuestsQuery(searchTerm));
        return Ok(result);
    }

    [HttpGet("{id}/active-stay")]
    [Authorize]
    public async Task<IActionResult> GetActiveStay(Guid id)
    {
        var result = await _mediator.Send(new GetActiveStayQuery(id));
        if (result == null) return NotFound("No active stay found for this guest.");
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> DeleteGuest(Guid id)
    {
        var result = await _mediator.Send(new DeleteGuestCommand(id));
        return Ok(new { success = result, message = "Guest deactivated successfully." });
    }
    [HttpPost("{id}/blacklist")]
    [Authorize(Roles = "Admin,SecurityManager,GeneralManager")]
    public async Task<IActionResult> BlacklistGuest(Guid id, [FromBody] BlacklistGuestCommand command)
    {
        var result = await _mediator.Send(command with { GuestId = id });
        return Ok(new { success = result, message = "Guest has been successfully added to the security blacklist." });
    }
    [HttpPost("{id}/preferences")]
    [Authorize(Roles = "Admin,Manager,Receptionist,Concierge")]
    public async Task<IActionResult> AddGuestPreference(Guid id, [FromBody] AddGuestPreferenceCommand command)
    {
        var result = await _mediator.Send(command with { GuestId = id });
        return Ok(new { success = result, message = "Guest preference successfully recorded." });
    }
    [HttpGet("{id}/loyalty-tier")]
    [Authorize(Roles = "Admin,Manager,Receptionist")]
    public async Task<IActionResult> GetGuestLoyalty(Guid id)
    {
        var result = await _mediator.Send(new GetGuestLoyaltyQuery(id));
        return Ok(result);
    }
    [HttpPost("{id}/loyalty-tier")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> UpdateGuestLoyalty(Guid id, [FromBody] UpdateLoyaltyTierCommand command)
    {
        var result = await _mediator.Send(command with { GuestId = id });
        return Ok(new { success = result, message = "Guest loyalty tier and points updated successfully." });
    }
    [HttpPost("{id}/document-verify")]
    [Authorize(Roles = "Admin,Manager,Receptionist")]
    public async Task<IActionResult> VerifyGuestDocument(Guid id, [FromBody] VerifyGuestDocumentCommand command)
    {
        var result = await _mediator.Send(command with { GuestId = id });
        return Ok(new { success = result, message = "Guest identification document successfully verified and logged for legal compliance." });
    }
    [HttpGet("{id}/spend-analytics")]
    [Authorize(Roles = "Admin,Manager,FinanceManager")]
    public async Task<IActionResult> GetGuestSpendAnalytics(Guid id)
    {
        var result = await _mediator.Send(new GetGuestSpendAnalyticsQuery(id));
        return Ok(result);
    }
}