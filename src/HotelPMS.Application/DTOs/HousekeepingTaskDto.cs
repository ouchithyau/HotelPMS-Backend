using HotelPMS.Domain.Enums;

namespace HotelPMS.Application.DTOs;

public record HousekeepingTaskDto(
    Guid Id,
    Guid RoomId,
    string RoomNumber,
    HousekeepingStatus Status,
    string? Notes,
    string? AssignedToStaffName,
    DateTime CreatedAt
);