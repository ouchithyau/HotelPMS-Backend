using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.Reservations.Queries.GetBookingById;

public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, Booking>
{
    private readonly IApplicationDbContext _context;

    public GetBookingByIdQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<Booking> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var booking = await _context.Bookings
            .Include(b => b.Guest)
            .Include(b => b.Room)
            .ThenInclude(r => r.RoomType)
            .Include(b => b.BookingServices)
            .ThenInclude(bs => bs.ExtraService)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (booking == null) throw new DomainException("Booking not found.");
        return booking;
    }
}