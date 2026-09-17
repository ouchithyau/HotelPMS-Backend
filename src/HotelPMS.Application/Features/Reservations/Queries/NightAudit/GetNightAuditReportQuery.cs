using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Reservations.Queries.NightAudit;

public record GetNightAuditReportQuery(DateTime AuditDate) : IRequest<NightAuditReportDto>;