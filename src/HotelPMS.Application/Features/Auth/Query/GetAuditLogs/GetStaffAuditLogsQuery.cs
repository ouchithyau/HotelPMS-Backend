using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Auth.Queries.GetAuditLogs;

public record GetStaffAuditLogsQuery(DateTime? StartDate, DateTime? EndDate) : IRequest<IEnumerable<AuditLogDto>>;