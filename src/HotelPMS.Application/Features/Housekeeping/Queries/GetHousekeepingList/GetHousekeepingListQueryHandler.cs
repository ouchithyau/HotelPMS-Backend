using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Housekeeping.Queries.GetHousekeepingList;

public class GetHousekeepingListQueryHandler : IRequestHandler<GetHousekeepingListQuery, IEnumerable<HousekeepingTask>>
{
    private readonly IApplicationDbContext _context;

    public GetHousekeepingListQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<HousekeepingTask>> Handle(GetHousekeepingListQuery request, CancellationToken cancellationToken)
    {
        return await _context.HousekeepingTasks
            .Include(t => t.Room)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}