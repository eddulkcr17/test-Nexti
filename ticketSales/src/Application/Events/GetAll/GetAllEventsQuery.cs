using ErrorOr;
using Events.Common;
using MediatR;

namespace Application.Events.GetAll;

public record GetAllEventsQuery(): IRequest<ErrorOr<IReadOnlyList<EventResponse>>>;