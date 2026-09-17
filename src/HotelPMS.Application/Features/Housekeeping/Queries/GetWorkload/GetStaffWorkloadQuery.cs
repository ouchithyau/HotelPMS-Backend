using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Housekeeping.Queries.GetWorkload;

public record GetStaffWorkloadQuery(string StaffId, DateTime Date) : IRequest<StaffWorkloadDto>;