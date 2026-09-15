using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.RoomTypes.Queries.GetRoomTypes;

public class GetRoomTypesQueryHandler : IRequestHandler<GetRoomTypesQuery, IEnumerable<RoomType>>
{
    private readonly IApplicationDbContext _context;

    public GetRoomTypesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RoomType>> Handle(GetRoomTypesQuery request, CancellationToken cancellationToken)
    {
        return await _context.RoomTypes
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}