using MediatR;

namespace HotelPMS.Application.Features.Auth.Commands.Enable2FA;

public record Enable2FACommand(string UserId) : IRequest<string>; // Returns QR Code / Secret