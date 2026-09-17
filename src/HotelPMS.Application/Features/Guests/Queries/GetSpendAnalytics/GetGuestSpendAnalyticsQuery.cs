using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Guests.Queries.GetSpendAnalytics;

public record GetGuestSpendAnalyticsQuery(Guid GuestId) : IRequest<GuestSpendAnalyticsDto>;