using MediatR;

namespace HotelPMS.Application.Features.Billing.Commands.SplitFolio;

public record SplitFolioCommand(
    Guid ReservationId,
    Guid ChargeId,
    string TargetFolioType // e.g., "FolioA" (Corporate) or "FolioB" (Personal)
) : IRequest<bool>;