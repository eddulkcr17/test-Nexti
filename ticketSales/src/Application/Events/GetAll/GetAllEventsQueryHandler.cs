using System.Collections.Immutable;
using Domain.Events;
using ErrorOr;
using Events.Common;
using MediatR;

namespace Application.Events.GetAll;

internal sealed class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, ErrorOr<IReadOnlyList<EventResponse>>>
{

private readonly IEventRepository _eventRepository;

    public GetAllEventsQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<EventResponse>>> Handle(GetAllEventsQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Event> events = await _eventRepository.GetAll();
        return events.Select(evnetTicket => new EventResponse(
            evnetTicket.Id.Value,
            evnetTicket.EventDate,
            new AddressResponse(evnetTicket.EventLocation.Country,
            evnetTicket.EventLocation.Line1,
            evnetTicket.EventLocation.Line2,
            evnetTicket.EventLocation.City,
            evnetTicket.EventLocation.State,
            evnetTicket.EventLocation.ZipCode),
            evnetTicket.EventDescription,
            evnetTicket.EventCost,
            evnetTicket.EventActive            
        )).ToList();
         
    }
}


  