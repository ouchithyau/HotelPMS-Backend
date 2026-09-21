using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Billing.Commands.Payment;

public record ProcessTokenizedPaymentCommand(
    TokenizedPaymentDto PaymentDetails
) : IRequest<bool>;