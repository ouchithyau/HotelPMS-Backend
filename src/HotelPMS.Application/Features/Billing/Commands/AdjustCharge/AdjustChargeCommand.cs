using MediatR;

namespace HotelPMS.Application.Features.Billing.Commands.AdjustCharge;

public record AdjustChargeCommand(
    Guid ReservationId,
    Guid ChargeId,
    decimal AdjustmentAmount,
    string Reason,
    string ManagerPinOrApprovalCode
) : IRequest<bool>;