using FluentValidation;

namespace HotelPMS.Application.Features.RoomTypes.Commands.CreateRoomType;

public class CreateRoomTypeCommandValidator : AbstractValidator<CreateRoomTypeCommand>
{
    public CreateRoomTypeCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Room type name is required.")
            .MaximumLength(100);

        RuleFor(v => v.BasePrice)
            .GreaterThan(0).WithMessage("Base price must be greater than zero.");

        RuleFor(v => v.MaxAdults)
            .GreaterThan(0).WithMessage("Max adults must be at least 1.");

        RuleFor(v => v.MaxChildren)
            .GreaterThanOrEqualTo(0);
    }
}