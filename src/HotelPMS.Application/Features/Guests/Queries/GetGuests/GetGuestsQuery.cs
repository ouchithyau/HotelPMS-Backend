using MediatR;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Guests.Queries.GetGuests;

public record GetGuestsQuery() : IRequest<IEnumerable<Guest>>;