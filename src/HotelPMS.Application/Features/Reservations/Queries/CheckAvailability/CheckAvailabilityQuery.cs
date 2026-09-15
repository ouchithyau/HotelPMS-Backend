using MediatR;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Reservations.Queries.CheckAvailability;

public record CheckAvailabilityQuery(DateTime CheckInDate, DateTime CheckOutDate) : IRequest<IEnumerable<Room>>;