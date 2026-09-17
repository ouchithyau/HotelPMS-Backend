using MediatR;

namespace HotelPMS.Application.Features.Billing.Commands.TransferCharge;

public record TransferChargeCommand(
    Guid SourceReservationId,
    Guid TargetReservationId,
    Guid ChargeId,
    decimal Amount
) : IRequest<bool>;