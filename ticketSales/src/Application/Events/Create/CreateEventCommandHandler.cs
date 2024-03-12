using Domain.Events;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using Domain.DomainErrors;

namespace Application.Events.Create;

public sealed class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ErrorOr<Unit>>
{
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateEventCommand command, CancellationToken cancellationToken)
    {

        if (Address.Create(command.Country, command.Line1, command.Line2,
        command.City, command.State, command.ZipCode) is not Address address)
        {
            return Errors.Events.AddressWithBadFormat;
        }

        var eventTicket = new Event(
            new EventId(Guid.NewGuid()),
            command.EventDate,
            address,
            command.EventDescription,
            command.EventCost,
            command.EventState
        );

        _eventRepository.Add(eventTicket);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}

