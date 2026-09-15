using MediatR;

namespace HotelPMS.Application.Features.RoomTypes.Commands.CreateRoomType;

public record CreateRoomTypeCommand(
    string Name,
    string Description,
    decimal BasePrice,
    int MaxAdults,
    int MaxChildren
) : IRequest<Guid>;