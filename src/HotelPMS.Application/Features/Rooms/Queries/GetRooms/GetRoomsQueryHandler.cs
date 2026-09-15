using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Rooms.Queries.GetRooms;

public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, IEnumerable<Room>>
{
    private readonly IApplicationDbContext _context;

    public GetRoomsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Room>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Rooms
            .Include(r => r.RoomType)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}