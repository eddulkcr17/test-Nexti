using ErrorOr;
using MediatR;

namespace Application.Events.Create;

public record CreateEventCommand(
    string EventDate,
    string EventDescription,
    string Country,
    string Line1,
    string Line2,
    string City,
    string State,
    string ZipCode,
    string EventCost,
    string EventState
): IRequest<ErrorOr<Unit>>;