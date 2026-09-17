using MediatR;

namespace HotelPMS.Application.Features.Auth.Commands.Verify2FA;

public record Verify2FACommand(string UserId, string Code) : IRequest<bool>;