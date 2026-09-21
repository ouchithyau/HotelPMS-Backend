using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.RoomTypes.Commands.BedConfigurations;

public record ConfigureBedTypesCommand(
    Guid RoomTypeId,
    List<BedConfigurationDto> BedConfigurations
) : IRequest<bool>;