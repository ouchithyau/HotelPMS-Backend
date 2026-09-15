using MediatR;
using HotelPMS.Domain.Enums;

namespace HotelPMS.Application.Features.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(
    string RoomNumber,
    Guid RoomTypeId,
    RoomStatus Status = RoomStatus.Available
) : IRequest<Guid>;