using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Reservations.Queries.GetBookingsByDateRange;

public class GetBookingsByDateRangeQueryHandler : IRequestHandler<GetBookingsByDateRangeQuery, IEnumerable<Booking>>
{
    private readonly IApplicationDbContext _context;

    public GetBookingsByDateRangeQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Booking>> Handle(GetBookingsByDateRangeQuery request, CancellationToken cancellationToken)
    {
        return await _context.Bookings
            .Include(b => b.Guest)
            .Include(b => b.Room)
            .Where(b => b.CheckInDate >= request.StartDate && b.CheckOutDate <= request.EndDate)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}