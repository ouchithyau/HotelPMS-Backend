using MediatR;

namespace HotelPMS.Application.Features.Billing.Commands.AddExtraService;

public record AddExtraServiceCommand(
    Guid BookingId,
    Guid ExtraServiceId,
    int Quantity
) : IRequest<Guid>;