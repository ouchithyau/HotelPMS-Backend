using MediatR;

namespace HotelPMS.Application.Features.Housekeeping.Commands.AssignTask;

public record AssignHousekeepingTaskCommand(
    Guid TaskId,
    Guid StaffId,
    string Priority
) : IRequest<bool>;