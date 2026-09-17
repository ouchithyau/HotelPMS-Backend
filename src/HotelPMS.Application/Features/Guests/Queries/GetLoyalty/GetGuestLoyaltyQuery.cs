using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Guests.Queries.GetLoyalty;

public record GetGuestLoyaltyQuery(Guid GuestId) : IRequest<LoyaltyDto>;