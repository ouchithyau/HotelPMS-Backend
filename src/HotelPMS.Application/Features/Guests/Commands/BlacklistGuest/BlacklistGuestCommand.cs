using MediatR;

namespace HotelPMS.Application.Features.Guests.Commands.BlacklistGuest;

public record BlacklistGuestCommand(
    Guid GuestId,
    string Reason,
    string BlacklistedBy
) : IRequest<bool>;