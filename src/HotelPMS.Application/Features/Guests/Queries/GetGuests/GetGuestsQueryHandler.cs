using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Guests.Queries.GetGuests;

public class GetGuestsQueryHandler : IRequestHandler<GetGuestsQuery, IEnumerable<Guest>>
{
    private readonly IApplicationDbContext _context;
    public GetGuestsQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Guest>> Handle(GetGuestsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Guests.AsNoTracking().ToListAsync(cancellationToken);
    }
}