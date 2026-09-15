using FluentValidation;

namespace HotelPMS.Application.Features.Guests.Commands.CreateGuest;

public class CreateGuestCommandValidator : AbstractValidator<CreateGuestCommand>
{
    public CreateGuestCommandValidator()
    {
        RuleFor(v => v.FullName).NotEmpty().MaximumLength(150);
        RuleFor(v => v.Email).NotEmpty().EmailAddress();
        RuleFor(v => v.PhoneNumber).NotEmpty();
        RuleFor(v => v.IdentificationNumber).NotEmpty();
    }
}