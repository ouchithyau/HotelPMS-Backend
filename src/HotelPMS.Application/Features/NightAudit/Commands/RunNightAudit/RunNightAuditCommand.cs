using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.NightAudit.Commands.RunNightAudit;

public record RunNightAuditCommand(
    DateTime BusinessDate,
    string StaffId
) : IRequest<NightAuditSummaryDto>;