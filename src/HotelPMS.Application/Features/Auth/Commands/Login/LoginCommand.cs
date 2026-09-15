using MediatR;

namespace HotelPMS.Application.Features.Auth.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<string>; // Returns JWT token