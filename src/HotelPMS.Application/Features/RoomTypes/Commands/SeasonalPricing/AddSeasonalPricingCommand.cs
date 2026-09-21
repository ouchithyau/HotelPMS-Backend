using MediatR;

namespace HotelPMS.Application.Features.RoomTypes.Commands.SeasonalPricing;

public record AddSeasonalPricingCommand(
    Guid RoomTypeId,
    string SeasonName,
    DateTime StartDate,
    DateTime EndDate,
    decimal PriceMultiplier
) : IRequest<bool>;