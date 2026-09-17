using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Billing.Queries.GetDailyRevenue;

public record GetDailyRevenueSummaryQuery(DateTime BusinessDate) : IRequest<RevenueSummaryDto>;