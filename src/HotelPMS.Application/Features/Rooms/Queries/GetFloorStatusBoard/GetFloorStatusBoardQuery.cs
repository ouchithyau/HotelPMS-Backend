using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Rooms.Queries.GetFloorStatusBoard;

public record GetFloorStatusBoardQuery() : IRequest<List<RoomStatusBoardDto>>;