using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.Rooms.Queries.GetRoomById;

public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, Room>
{
    private readonly IApplicationDbContext _context;

    public GetRoomByIdQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<Room> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await _context.Rooms
            .Include(r => r.RoomType)
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (room == null) throw new DomainException("Room not found.");
        return room;
    }
}