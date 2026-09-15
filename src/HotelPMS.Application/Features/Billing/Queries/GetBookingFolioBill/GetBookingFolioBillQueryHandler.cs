using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.Billing.Queries.GetBookingFolioBill;

public class GetBookingFolioBillQueryHandler : IRequestHandler<GetBookingFolioBillQuery, FolioBillDto>
{
    private readonly IApplicationDbContext _context;

    public GetBookingFolioBillQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<FolioBillDto> Handle(GetBookingFolioBillQuery request, CancellationToken cancellationToken)
    {
        var booking = await _context.Bookings
            .Include(b => b.BookingServices)
            .ThenInclude(bs => bs.ExtraService)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking == null) throw new DomainException("Booking not found.");

        var extrasTotal = booking.BookingServices.Sum(s => s.TotalPrice);
        var grandTotal = booking.TotalAmount + extrasTotal;

        return new FolioBillDto(
            booking.Id,
            booking.BookingReference,
            booking.TotalAmount,
            booking.BookingServices,
            grandTotal
        );
    }
}