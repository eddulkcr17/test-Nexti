using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Events;

public sealed class Event : AggregateRoot
{
    public Event()
    {

    }

    public Event(EventId id, string eventDate, Address eventLocation, string eventDescription, string eventCost, string eventActive)
    {
        Id = id;
        EventDate = eventDate;
        EventLocation = eventLocation;
        EventDescription = eventDescription;
        EventCost = eventCost;
        EventActive = eventActive;
    }

     

    public EventId Id { get; private set; }
    public string EventDate { get; set; } = string.Empty;
    public Address EventLocation { get; private set; }
    public string EventDescription { get; set; } = string.Empty;
    public string EventCost { get; set; } = string.Empty;
    public string EventActive { get; set; } = string.Empty;

    public static Event UpdateEvent(Guid id, string eventDate, Address eventLocation, string eventDescription, string eventCost, string eventActive)
    {
        return new Event(new EventId(id), eventDate,eventLocation,eventDescription,eventCost,eventActive);
    }

}