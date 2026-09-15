using MediatR;

namespace HotelPMS.Application.Features.Guests.Commands.CreateGuest;

public record CreateGuestCommand(
    string FullName,
    string Email,
    string PhoneNumber,
    string IdentificationNumber,
    string Address
) : IRequest<Guid>;