namespace HotelPMS.Application.DTOs;

public record GuestDto(
    Guid Id,
    string FullName,
    string Email,
    string PhoneNumber,
    string IdentificationNumber,
    string Address
);