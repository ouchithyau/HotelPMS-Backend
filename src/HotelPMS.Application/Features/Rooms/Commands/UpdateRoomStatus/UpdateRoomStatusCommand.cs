using MediatR;
using HotelPMS.Domain.Enums;

namespace HotelPMS.Application.Features.Rooms.Commands.UpdateRoomStatus;

public record UpdateRoomStatusCommand(Guid RoomId, RoomStatus Status) : IRequest<Unit>;