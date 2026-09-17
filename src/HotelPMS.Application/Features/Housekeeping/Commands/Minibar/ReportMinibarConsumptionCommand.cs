using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Housekeeping.Commands.Minibar;

public record ReportMinibarConsumptionCommand(
    Guid RoomId,
    Guid ReservationId,
    string HousekeepingStaffId,
    List<MinibarItemUsageDto> ConsumedItems
) : IRequest<bool>;