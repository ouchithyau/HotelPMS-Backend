using MediatR;

namespace HotelPMS.Application.Features.Guests.Commands.DeleteGuest;

public record DeleteGuestCommand(Guid Id) : IRequest<bool>;