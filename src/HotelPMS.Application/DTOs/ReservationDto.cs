using HotelPMS.Domain.Enums;

namespace HotelPMS.Application.DTOs;

public record ReservationDto(
    Guid Id,
    string BookingReference,
    Guid GuestId,
    string GuestFullName,
    string GuestEmail,
    string GuestPhone,
    Guid RoomId,
    string RoomNumber,
    string RoomTypeName,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    int NumberOfGuests,
    decimal TotalAmount,
    BookingStatus BookingStatus,
    PaymentStatus PaymentStatus
);