using HotelPMS.Domain.Enums;

namespace HotelPMS.Application.DTOs;

public record RoomDto(
    Guid Id,
    string RoomNumber,
    Guid RoomTypeId,
    string RoomTypeName,
    RoomStatus Status
);