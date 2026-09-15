using MediatR;
using HotelPMS.Domain.Enums;

namespace HotelPMS.Application.Features.Auth.Commands.Register;

public record RegisterCommand(
    string FullName,
    string Email,
    string Password,
    UserRole Role
) : IRequest<Guid>;