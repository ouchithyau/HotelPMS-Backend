namespace HotelPMS.Application.DTOs;

public record RoomTypeDto(
    Guid Id,
    string Name,
    string Description,
    decimal BasePrice,
    int MaxAdults,
    int MaxChildren
);