using MediatR;
using HotelPMS.Application.DTOs; // Or your Housekeeping DTO

namespace HotelPMS.Application.Features.Housekeeping.Queries.GetRoomStatus;

public record GetRoomHousekeepingQuery(Guid RoomId) : IRequest<HousekeepingTaskDto>;