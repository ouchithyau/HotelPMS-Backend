using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Reservations.Queries.GetInvoice;

public record GetFinalInvoiceQuery(Guid ReservationId) : IRequest<InvoiceDto>;