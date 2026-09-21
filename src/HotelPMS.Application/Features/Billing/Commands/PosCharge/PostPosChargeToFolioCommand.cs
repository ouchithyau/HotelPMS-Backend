using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Billing.Commands.PosCharge;

public record PostPosChargeToFolioCommand(
    PosChargeSyncDto ChargeDetails
) : IRequest<bool>;