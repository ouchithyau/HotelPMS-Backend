using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.NoShow;

public record MarkNoShowCommand(Guid ReservationId) : IRequest<bool>;