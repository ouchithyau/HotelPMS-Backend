using MediatR;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.Guests.Commands.UpdateGuest;

public class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateGuestCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
    {
        var guest = await _context.Guests.FindAsync(new object[] { request.Id }, cancellationToken);
        if (guest == null) throw new DomainException("Guest not found.");

        guest.FullName = request.FullName;
        guest.Email = request.Email;
        guest.PhoneNumber = request.PhoneNumber;
        guest.IdentificationNumber = request.IdentificationNumber;
        guest.Address = request.Address;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}