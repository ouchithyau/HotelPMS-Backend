using MediatR;

namespace HotelPMS.Application.Features.Auth.Commands.Logout;

public record LogoutCommand(Guid UserId) : IRequest<bool>;