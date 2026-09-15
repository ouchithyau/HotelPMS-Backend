using FluentValidation;

namespace HotelPMS.Application.Features.Rooms.Commands.CreateRoom;

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(v => v.RoomNumber)
            .NotEmpty().WithMessage("Room number is required.")
            .MaximumLength(20);

        RuleFor(v => v.RoomTypeId)
            .NotEmpty().WithMessage("Room type ID is required.");
    }
}