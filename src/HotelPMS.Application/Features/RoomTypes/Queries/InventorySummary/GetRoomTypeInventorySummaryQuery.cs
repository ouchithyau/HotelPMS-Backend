using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.RoomTypes.Queries.InventorySummary;

public record GetRoomTypeInventorySummaryQuery(Guid RoomTypeId) : IRequest<RoomTypeInventorySummaryDto>;