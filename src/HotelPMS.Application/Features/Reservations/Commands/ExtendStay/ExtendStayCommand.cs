using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.ExtendStay;

public record ExtendStayCommand(
    Guid ReservationId,
    DateTime NewCheckOutDate
) : IRequest<bool>;