using MediatR;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.Rooms.Commands.UpdateRoomStatus;

public class UpdateRoomStatusCommandHandler : IRequestHandler<UpdateRoomStatusCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateRoomStatusCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(UpdateRoomStatusCommand request, CancellationToken cancellationToken)
    {
        var room = await _context.Rooms.FindAsync(new object[] { request.RoomId }, cancellationToken);
        if (room == null) throw new DomainException("Room not found.");

        room.Status = request.Status;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}