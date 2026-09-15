using MediatR;

namespace HotelPMS.Application.Features.RoomTypes.Commands.UpdateRoomType;

public record UpdateRoomTypeCommand(
    Guid Id,
    string Name,
    string Description,
    decimal BasePrice,
    int MaxAdults,
    int MaxChildren
) : IRequest<Unit>;