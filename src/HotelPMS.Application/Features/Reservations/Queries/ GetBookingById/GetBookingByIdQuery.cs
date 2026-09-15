using MediatR;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Reservations.Queries.GetBookingById;

public record GetBookingByIdQuery(Guid Id) : IRequest<Booking>;