using MediatR;

namespace HotelPMS.Application.Features.RoomTypes.Commands.DeleteRoomType;

public record DeleteRoomTypeCommand(Guid RoomTypeId) : IRequest<bool>;