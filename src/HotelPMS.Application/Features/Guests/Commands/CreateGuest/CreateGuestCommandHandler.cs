using MediatR;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Guests.Commands.CreateGuest;

public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateGuestCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Guid> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
    {
        var guest = new Guest
        {
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            IdentificationNumber = request.IdentificationNumber,
            Address = request.Address
        };

        _context.Guests.Add(guest);
        await _context.SaveChangesAsync(cancellationToken);

        return guest.Id;
    }
}