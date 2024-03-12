using FluentValidation;

namespace Application.Events.Update;

public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
{
    public UpdateEventCommandValidator()
    {
        RuleFor(r=>r.Id)
        .NotEmpty();

    }
}