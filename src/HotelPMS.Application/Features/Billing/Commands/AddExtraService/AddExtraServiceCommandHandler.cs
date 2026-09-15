using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.Billing.Commands.AddExtraService;

public class AddExtraServiceCommandHandler : IRequestHandler<AddExtraServiceCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public AddExtraServiceCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Guid> Handle(AddExtraServiceCommand request, CancellationToken cancellationToken)
    {
        var extraService = await _context.ExtraServices
            .FirstOrDefaultAsync(e => e.Id == request.ExtraServiceId, cancellationToken);

        if (extraService == null) throw new DomainException("Extra service not found.");

        var bookingService = new BookingService
        {
            BookingId = request.BookingId,
            ExtraServiceId = request.ExtraServiceId,
            Quantity = request.Quantity,
            UnitPrice = extraService.UnitPrice,
            TotalPrice = extraService.UnitPrice * request.Quantity
        };

        _context.BookingServices.Add(bookingService);
        await _context.SaveChangesAsync(cancellationToken);

        return bookingService.Id;
    }
}