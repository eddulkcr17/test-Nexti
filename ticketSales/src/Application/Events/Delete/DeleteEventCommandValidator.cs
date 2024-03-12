

using FluentValidation;

namespace  Application.Events.Delete;

public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>{
    public DeleteEventCommandValidator(){
        RuleFor(r=> r.Id)
        .NotEmpty();
    }
    
}
