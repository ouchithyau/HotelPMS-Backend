using MediatR;

namespace HotelPMS.Application.Features.Auth.Commands.ForgotPassword;

public record ForgotPasswordCommand(string Email) : IRequest<bool>;