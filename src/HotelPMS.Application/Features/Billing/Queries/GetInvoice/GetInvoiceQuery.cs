using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Billing.Queries.GetInvoice;

public record GetInvoiceQuery(Guid BookingId) : IRequest<InvoiceDto>;