using MediatR;

namespace HotelPMS.Application.Features.Rooms.Commands.Amenities;

public record AssignRoomAmenitiesCommand(
    Guid RoomId,
    List<Guid> AmenityIds
) : IRequest<bool>;