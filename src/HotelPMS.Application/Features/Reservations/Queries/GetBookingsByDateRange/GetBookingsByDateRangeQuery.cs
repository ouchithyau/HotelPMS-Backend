using MediatR;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Reservations.Queries.GetBookingsByDateRange;

public record GetBookingsByDateRangeQuery(DateTime StartDate, DateTime EndDate) : IRequest<IEnumerable<Booking>>;