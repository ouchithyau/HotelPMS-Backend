using MediatR;
using HotelPMS.Application.DTOs; // Or your Guest DTO

namespace HotelPMS.Application.Features.Guests.Queries.SearchGuests;

public record SearchGuestsQuery(string SearchTerm) : IRequest<IEnumerable<GuestDto>>;