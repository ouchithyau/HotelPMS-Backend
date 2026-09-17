using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Guests.Queries.GetActiveStay;

public record GetActiveStayQuery(Guid GuestId) : IRequest<ActiveStayDto>;