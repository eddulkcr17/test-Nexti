using FluentValidation;

namespace Application.Events.Create;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(r => r.EventDate)
        .NotEmpty()
        .MaximumLength(50);

        RuleFor(r => r.Country)
        .NotEmpty()
        .MaximumLength(3);
    }
}