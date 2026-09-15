using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.Reservations.Commands.CreateBooking;

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateBookingCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var isOverlap = await _context.Bookings.AnyAsync(b =>
            b.RoomId == request.RoomId &&
            b.CheckInDate < request.CheckOutDate &&
            b.CheckOutDate > request.CheckInDate &&
            b.BookingStatus != Domain.Enums.BookingStatus.Cancelled, cancellationToken);

        if (isOverlap)
            throw new DomainException("The room is already booked for the selected dates.");

        var room = await _context.Rooms
            .Include(r => r.RoomType)
            .FirstOrDefaultAsync(r => r.Id == request.RoomId, cancellationToken);

        if (room == null)
            throw new DomainException("Room not found.");

        var days = (request.CheckOutDate.Date - request.CheckInDate.Date).Days;
        if (days <= 0) throw new DomainException("Check-out date must be after check-in date.");

        var totalAmount = room.RoomType.BasePrice * days;

        var booking = new Booking
        {
            BookingReference = $"BK-{Guid.NewGuid().ToString().Substring(0, 6).ToUpper()}",
            GuestId = request.GuestId,
            RoomId = request.RoomId,
            CheckInDate = request.CheckInDate,
            CheckOutDate = request.CheckOutDate,
            NumberOfGuests = request.NumberOfGuests,
            TotalAmount = totalAmount,
            BookingStatus = Domain.Enums.BookingStatus.Confirmed
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync(cancellationToken);

        return booking.Id;
    }
}