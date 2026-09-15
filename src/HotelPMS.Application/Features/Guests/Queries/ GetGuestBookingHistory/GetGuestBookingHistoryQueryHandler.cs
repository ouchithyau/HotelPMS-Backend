using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Guests.Queries.GetGuestBookingHistory;

public class GetGuestBookingHistoryQueryHandler : IRequestHandler<GetGuestBookingHistoryQuery, IEnumerable<Booking>>
{
    private readonly IApplicationDbContext _context;

    public GetGuestBookingHistoryQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Booking>> Handle(GetGuestBookingHistoryQuery request, CancellationToken cancellationToken)
    {
        return await _context.Bookings
            .Include(b => b.Room)
            .Where(b => b.GuestId == request.GuestId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}