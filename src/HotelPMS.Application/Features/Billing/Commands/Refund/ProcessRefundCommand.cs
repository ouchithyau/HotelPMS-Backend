using MediatR;

namespace HotelPMS.Application.Features.Billing.Commands.Refund;

public record ProcessRefundCommand(
    Guid ReservationId,
    decimal RefundAmount,
    string RefundMethod, // e.g., "Cash", "CreditCard"
    string ReferenceNumber
) : IRequest<bool>;