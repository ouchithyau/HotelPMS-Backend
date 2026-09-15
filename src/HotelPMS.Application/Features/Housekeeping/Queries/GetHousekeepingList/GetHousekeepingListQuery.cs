using MediatR;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Features.Housekeeping.Queries.GetHousekeepingList;

public record GetHousekeepingListQuery() : IRequest<IEnumerable<HousekeepingTask>>;