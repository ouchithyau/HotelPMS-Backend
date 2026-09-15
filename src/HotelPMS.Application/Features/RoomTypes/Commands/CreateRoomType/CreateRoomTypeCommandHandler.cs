using MediatR;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.RoomTypes.Commands.CreateRoomType;

public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, Guid>
{
	private readonly IApplicationDbContext _context;

	public CreateRoomTypeCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Guid> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
	{
		var roomType = new RoomType
		{
			Name = request.Name,
			Description = request.Description,
			BasePrice = request.BasePrice,
			MaxAdults = request.MaxAdults,
			MaxChildren = request.MaxChildren
		};

		_context.RoomTypes.Add(roomType);
		await _context.SaveChangesAsync(cancellationToken);

		return roomType.Id;
	}
}