namespace HotelPMS.Application.DTOs;

public record BookingServiceDto(
    Guid Id,
    Guid ExtraServiceId,
    string ServiceName,
    int Quantity,
    decimal UnitPrice,
    decimal TotalPrice,
    DateTime ServiceDate
);