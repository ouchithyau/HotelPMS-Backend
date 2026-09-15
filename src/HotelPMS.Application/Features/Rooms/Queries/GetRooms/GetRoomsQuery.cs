using MediatR;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Rooms.Queries.GetRooms;

public record GetRoomsQuery() : IRequest<IEnumerable<Room>>;