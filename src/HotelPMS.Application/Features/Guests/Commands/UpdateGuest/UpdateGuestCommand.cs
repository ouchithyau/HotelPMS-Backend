using MediatR;

namespace HotelPMS.Application.Features.Guests.Commands.UpdateGuest;

public record UpdateGuestCommand(
    Guid Id,
    string FullName,
    string Email,
    string PhoneNumber,
    string IdentificationNumber,
    string Address
) : IRequest<Unit>;