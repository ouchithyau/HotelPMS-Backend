using MediatR;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Billing.Queries.GetBookingFolioBill;

public record FolioBillDto(
    Guid BookingId,
    string BookingReference,
    decimal RoomTotalAmount,
    IEnumerable<BookingService> ExtraServices,
    decimal TotalBillAmount
);

public record GetBookingFolioBillQuery(Guid BookingId) : IRequest<FolioBillDto>;