
namespace Events.Common;

public record EventResponse(
    Guid Id,
    string EventDate,
    AddressResponse EventLocation,
    string EventDescription,
    string EventCost,
    string EventActive);

    public record AddressResponse(
    string Country,
    string Line1,
    string Line2,
    string City,
    string State,
    string ZipCode);
