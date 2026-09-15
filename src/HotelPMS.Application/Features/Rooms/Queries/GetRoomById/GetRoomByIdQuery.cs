using MediatR;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Rooms.Queries.GetRoomById;

public record GetRoomByIdQuery(Guid Id) : IRequest<Room>;