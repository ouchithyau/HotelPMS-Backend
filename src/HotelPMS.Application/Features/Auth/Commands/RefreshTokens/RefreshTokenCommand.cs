using MediatR;
using HotelPMS.Application.DTOs; // Or wherever your AuthResponseDto is

namespace HotelPMS.Application.Features.Auth.Commands.RefreshToken;

public record RefreshTokenCommand(string AccessToken, string RefreshToken) : IRequest<AuthResponseDto>;