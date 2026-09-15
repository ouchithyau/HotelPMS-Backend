using MediatR;
using Microsoft.AspNetCore.Mvc;
using HotelPMS.Application.Features.Housekeeping.Commands.UpdateCleaningStatus;
using HotelPMS.Application.Features.Housekeeping.Queries.GetHousekeepingList;

namespace HotelPMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousekeepingController : ControllerBase
{
    private readonly IMediator _mediator;

    public HousekeepingController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await _mediator.Send(new GetHousekeepingListQuery());
        return Ok(result);
    }

    [HttpPut("status")]
    public async Task<IActionResult> UpdateStatus([FromBody] UpdateCleaningStatusCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}