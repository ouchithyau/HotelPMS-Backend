using MediatR;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Guests.Queries.GetGuestBookingHistory;

public record GetGuestBookingHistoryQuery(Guid GuestId) : IRequest<IEnumerable<Booking>>;