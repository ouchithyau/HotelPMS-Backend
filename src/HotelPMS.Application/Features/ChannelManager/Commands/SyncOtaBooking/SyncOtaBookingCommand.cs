using HotelPMS.Application.DTOs;
using MediatR;

namespace HotelPMS.Application.Features.ChannelManager.Commands.SyncOtaBooking;

public record SyncOtaBookingCommand(
    OtaBookingSyncDto BookingDetails
) : IRequest<bool>;