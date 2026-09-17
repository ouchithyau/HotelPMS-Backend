using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.AddSpecialRequests;

public record AddSpecialRequestsCommand(Guid ReservationId, string SpecialRequests) : IRequest<bool>;