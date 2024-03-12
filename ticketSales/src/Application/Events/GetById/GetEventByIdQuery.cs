using ErrorOr;
using Events.Common;
using MediatR;

namespace Application.Events.GetById;

public record GetEventByIdQuery(Guid Id): IRequest<ErrorOr<EventResponse>>;