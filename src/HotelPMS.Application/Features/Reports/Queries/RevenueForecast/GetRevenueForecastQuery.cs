using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Reports.Queries.RevenueForecast;

public record GetRevenueForecastQuery(
    DateTime StartDate,
    DateTime EndDate
) : IRequest<List<RevenueForecastReportDto>>;