using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Reservations.Queries.GetAvailability;

public record GetRoomAvailabilityQuery(DateTime CheckIn, DateTime CheckOut) : IRequest<IEnumerable<AvailabilityDto>>;