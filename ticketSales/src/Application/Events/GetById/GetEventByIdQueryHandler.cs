using Domain.Events;
using ErrorOr;
using Events.Common;
using MediatR;

namespace Application.Events.GetById;

internal sealed class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, ErrorOr<EventResponse>>{
    private readonly IEventRepository _eventRepository;

    public GetEventByIdQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
    }

    public async Task<ErrorOr<EventResponse>> Handle(GetEventByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _eventRepository.GetByIdAsync(new EventId(query.Id)) is not Event eventTicket)
        {
            return Error.NotFound("Event.notFound", "the event with provide Id was not found");
        }
        return new EventResponse( eventTicket.Id.Value,
            eventTicket.EventDate,
            new AddressResponse(eventTicket.EventLocation.Country,
            eventTicket.EventLocation.Line1,
            eventTicket.EventLocation.Line2,
            eventTicket.EventLocation.City,
            eventTicket.EventLocation.State,
            eventTicket.EventLocation.ZipCode),
            eventTicket.EventDescription,
            eventTicket.EventCost,
            eventTicket.EventActive);
         
    }
}