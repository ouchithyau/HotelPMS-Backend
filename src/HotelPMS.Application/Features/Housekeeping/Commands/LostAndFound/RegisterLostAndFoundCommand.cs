using MediatR;

namespace HotelPMS.Application.Features.Housekeeping.Commands.LostAndFound;

public record RegisterLostAndFoundCommand(
    Guid RoomId,
    string ItemName,
    string Description,
    string FoundByStaffId,
    string StorageLocation
) : IRequest<bool>;