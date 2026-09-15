using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Enums;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.Housekeeping.Commands.UpdateCleaningStatus;

public class UpdateCleaningStatusCommandHandler : IRequestHandler<UpdateCleaningStatusCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateCleaningStatusCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(UpdateCleaningStatusCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.HousekeepingTasks
            .FirstOrDefaultAsync(t => t.RoomId == request.RoomId, cancellationToken);

        if (task == null)
        {
            task = new Domain.Entities.HousekeepingTask
            {
                RoomId = request.RoomId,
                Status = request.Status,
                Notes = request.Notes,
                AssignedToStaffName = request.StaffName
            };
            _context.HousekeepingTasks.Add(task);
        }
        else
        {
            task.Status = request.Status;
            task.Notes = request.Notes;
            task.AssignedToStaffName = request.StaffName;
        }

        var room = await _context.Rooms.FindAsync(new object[] { request.RoomId }, cancellationToken);
        if (room != null)
        {
            room.Status = request.Status == HousekeepingStatus.Clean ? RoomStatus.Available : RoomStatus.Cleaning;
        }

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}