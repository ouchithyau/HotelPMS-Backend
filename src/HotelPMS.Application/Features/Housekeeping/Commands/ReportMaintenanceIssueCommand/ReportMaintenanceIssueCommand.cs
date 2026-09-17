using MediatR;

namespace HotelPMS.Application.Features.Housekeeping.Commands.ReportIssue;

public record ReportMaintenanceIssueCommand(
    Guid RoomId,
    string IssueDescription
) : IRequest<bool>;