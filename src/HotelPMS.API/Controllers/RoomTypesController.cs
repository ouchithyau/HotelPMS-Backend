using HotelPMS.Application.Features.RoomTypes.Commands.BedConfigurations;
using HotelPMS.Application.Features.RoomTypes.Commands.CreateRoomType;
using HotelPMS.Application.Features.RoomTypes.Commands.DeleteRoomType;
using HotelPMS.Application.Features.RoomTypes.Commands.OccupancyRules;
using HotelPMS.Application.Features.RoomTypes.Commands.SeasonalPricing;
using HotelPMS.Application.Features.RoomTypes.Commands.UpdateRoomType;
using HotelPMS.Application.Features.RoomTypes.Queries.GetRoomTypes;
using HotelPMS.Application.Features.RoomTypes.Queries.InventorySummary;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    [HttpPost("{id}/seasonal-pricing")]
    [Authorize(Roles = "Admin,RevenueManager,Manager")]
    public async Task<IActionResult> AddSeasonalPricing(Guid id, [FromBody] AddSeasonalPricingCommand command)
    {
        var result = await _mediator.Send(command with { RoomTypeId = id });
        return Ok(new { success = result, message = "Seasonal pricing and dynamic rate multiplier successfully configured." });
    }
    [HttpPut("{id}/occupancy-rules")]
    [Authorize(Roles = "Admin,RevenueManager,FrontOfficeManager")]
    public async Task<IActionResult> UpdateOccupancyRules(Guid id, [FromBody] UpdateOccupancyRulesCommand command)
    {
        var result = await _mediator.Send(command with { RoomTypeId = id });
        return Ok(new { success = result, message = "Room type occupancy limits and extra bed policies successfully updated." });
    }
    [HttpGet("{id}/inventory-summary")]
    [Authorize(Roles = "Admin,RevenueManager,FrontOfficeManager")]
    public async Task<IActionResult> GetInventorySummary(Guid id)
    {
        var result = await _mediator.Send(new GetRoomTypeInventorySummaryQuery(id));
        return Ok(result);
    }
    [HttpPost("{id}/bed-configurations")]
    [Authorize(Roles = "Admin,RevenueManager,FrontOfficeManager")]
    public async Task<IActionResult> ConfigureBedTypes(Guid id, [FromBody] ConfigureBedTypesCommand command)
    {
        var result = await _mediator.Send(command with { RoomTypeId = id });
        return Ok(new { success = result, message = "Room type bed configurations successfully updated." });
    }
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,RevenueManager")]
    public async Task<IActionResult> DeleteRoomType(Guid id)
    {
        var result = await _mediator.Send(new DeleteRoomTypeCommand(id));
        return Ok(new { success = result, message = "Room type safely deleted or deactivated (Guard checked for active future reservations)." });
    }
}