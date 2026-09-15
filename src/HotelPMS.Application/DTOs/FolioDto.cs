using HotelPMS.Domain.Enums;

namespace HotelPMS.Application.DTOs;

public record FolioDto(
    Guid BookingId,
    string BookingReference,
    string GuestName,
    string RoomNumber,
    decimal RoomTotalAmount,
    IEnumerable<BookingServiceDto> ExtraServices,
    decimal GrandTotalAmount,
    PaymentStatus PaymentStatus
);