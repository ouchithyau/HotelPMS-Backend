using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Reservations.Queries.CheckAvailability;

public class CheckAvailabilityQueryHandler : IRequestHandler<CheckAvailabilityQuery, IEnumerable<Room>>
{
    private readonly IApplicationDbContext _context;

    public CheckAvailabilityQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Room>> Handle(CheckAvailabilityQuery request, CancellationToken cancellationToken)
    {
        var bookedRoomIds = await _context.Bookings
            .Where(b => b.CheckInDate < request.CheckOutDate &&
                        b.CheckOutDate > request.CheckInDate &&
                        b.BookingStatus != Domain.Enums.BookingStatus.Cancelled)
            .Select(b => b.RoomId)
            .ToListAsync(cancellationToken);

        return await _context.Rooms
            .Include(r => r.RoomType)
            .Where(r => !bookedRoomIds.Contains(r.Id))
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}