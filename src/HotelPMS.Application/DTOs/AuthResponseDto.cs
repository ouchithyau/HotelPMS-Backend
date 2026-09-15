using HotelPMS.Domain.Enums;

namespace HotelPMS.Application.DTOs;

public record AuthResponseDto(
    Guid UserId,
    string FullName,
    string Email,
    UserRole Role,
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpiryTime
);