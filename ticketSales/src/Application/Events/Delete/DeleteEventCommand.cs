using ErrorOr;
using MediatR;

namespace Application.Events.Delete;

public record DeleteEventCommand(Guid Id): IRequest<ErrorOr<Unit>>;