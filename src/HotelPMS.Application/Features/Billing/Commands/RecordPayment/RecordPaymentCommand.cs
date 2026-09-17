using MediatR;

namespace HotelPMS.Application.Features.Billing.Commands.RecordPayment;

public record RecordPaymentCommand(
    Guid BookingId,
    decimal Amount,
    string PaymentMethod // e.g., Cash, CreditCard, BankTransfer
) : IRequest<bool>;