using MediatR;

namespace HotelPMS.Application.Features.Reports.Queries.ExportReports;

public record ExportRevenueReportQuery(
    DateTime StartDate,
    DateTime EndDate,
    string Format // "pdf" or "excel"
) : IRequest<byte[]>;