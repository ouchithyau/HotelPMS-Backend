using MediatR;

namespace HotelPMS.Application.Features.Guests.Commands.AddPreference;

public record AddGuestPreferenceCommand(
    Guid GuestId,
    string Category,
    string PreferenceValue,
    string Notes
) : IRequest<bool>;