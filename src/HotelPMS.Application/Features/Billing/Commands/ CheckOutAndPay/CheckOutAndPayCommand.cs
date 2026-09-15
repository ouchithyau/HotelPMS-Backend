using MediatR;
using HotelPMS.Domain.Enums;

namespace HotelPMS.Application.Features.Billing.Commands.CheckOutAndPay;

public record CheckOutAndPayCommand(Guid BookingId, PaymentStatus PaymentStatus) : IRequest<Unit>;