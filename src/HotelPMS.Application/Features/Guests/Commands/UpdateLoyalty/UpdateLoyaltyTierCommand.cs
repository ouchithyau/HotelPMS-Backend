using MediatR;

namespace HotelPMS.Application.Features.Guests.Commands.UpdateLoyalty;

public record UpdateLoyaltyTierCommand(
    Guid GuestId,
    string NewTierName,
    int BonusPointsToAdd
) : IRequest<bool>;