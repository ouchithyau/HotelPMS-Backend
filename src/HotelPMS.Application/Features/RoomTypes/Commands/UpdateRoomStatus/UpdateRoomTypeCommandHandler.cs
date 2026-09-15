using MediatR;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.RoomTypes.Commands.UpdateRoomType;

public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateRoomTypeCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
    {
        var roomType = await _context.RoomTypes.FindAsync(new object[] { request.Id }, cancellationToken);
        if (roomType == null) throw new DomainException("RoomType not found.");

        roomType.Name = request.Name;
        roomType.Description = request.Description;
        roomType.BasePrice = request.BasePrice;
        roomType.MaxAdults = request.MaxAdults;
        roomType.MaxChildren = request.MaxChildren;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}