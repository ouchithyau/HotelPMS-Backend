using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Rooms.Queries.GetAvailabilityMatrix;

public record GetRoomAvailabilityMatrixQuery(
    DateTime StartDate,
    DateTime EndDate
) : IRequest<List<RoomAvailabilityDto>>;