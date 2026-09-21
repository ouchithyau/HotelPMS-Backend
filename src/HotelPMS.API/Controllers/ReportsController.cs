using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HotelPMS.Application.Features.Reports.Queries.RevenueForecast;
using HotelPMS.Application.Features.Reports.Queries.ExportReports;

namespace HotelPMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("revenue-forecast")]
    [Authorize(Roles = "Admin,RevenueManager,GeneralManager,FinanceManager")]
    public async Task<IActionResult> GetRevenueForecast([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var result = await _mediator.Send(new GetRevenueForecastQuery(startDate, endDate));
        return Ok(result);
    }

    [HttpGet("export")]
    [Authorize(Roles = "Admin,RevenueManager,GeneralManager,FinanceManager")]
    public async Task<IActionResult> ExportReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] string format = "pdf")
    {
        var fileBytes = await _mediator.Send(new ExportRevenueReportQuery(startDate, endDate, format));
        string contentType = format.ToLower() == "excel"
            ? "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            : "application/pdf";
        string fileName = $"Revenue_Forecast_Report_{DateTime.UtcNow:yyyyMMdd}.{(format.ToLower() == "excel" ? "xlsx" : "pdf")}";

        return File(fileBytes, contentType, fileName);
    }
}