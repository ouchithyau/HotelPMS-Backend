using MediatR;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.RoomTypes.Queries.GetRoomTypes;

public record GetRoomTypesQuery() : IRequest<IEnumerable<RoomType>>;