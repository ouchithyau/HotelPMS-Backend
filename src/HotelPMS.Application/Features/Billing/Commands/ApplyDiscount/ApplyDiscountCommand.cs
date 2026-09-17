using MediatR;

namespace HotelPMS.Application.Features.Billing.Commands.ApplyDiscount;

public record ApplyDiscountCommand(
    Guid BookingId,
    decimal DiscountAmount,
    string Reason
) : IRequest<bool>; // Meka anithyryenma thiyenna oni!