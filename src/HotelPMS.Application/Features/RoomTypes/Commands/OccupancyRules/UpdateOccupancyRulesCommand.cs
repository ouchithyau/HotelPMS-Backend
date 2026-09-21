using MediatR;

namespace HotelPMS.Application.Features.RoomTypes.Commands.OccupancyRules;

public record UpdateOccupancyRulesCommand(
    Guid RoomTypeId,
    int MaxAdults,
    int MaxChildren,
    bool AllowExtraBed,
    decimal ExtraBedCharge
) : IRequest<bool>;