using MediatR;

namespace HotelPMS.Application.Features.Auth.Commands.RevokeToken;

public record RevokeTokenCommand(string Token) : IRequest<bool>;