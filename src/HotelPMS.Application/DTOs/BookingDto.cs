using HotelPMS.Domain.Enums;

namespace HotelPMS.Application.DTOs;

public record BookingDto(
    Guid Id,
    string BookingReference,
    Guid GuestId,
    string GuestName,
    Guid RoomId,
    string RoomNumber,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    int NumberOfGuests,
    decimal TotalAmount,
    BookingStatus BookingStatus,
    PaymentStatus PaymentStatus
);