using Domain.Events;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Events.Update;

internal sealed class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, ErrorOr<Unit>>
{
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository?? throw new ArgumentNullException(nameof(eventRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
    {
        if (await _eventRepository.ExistsAsync(new EventId(command.Id)))
        {
            return Error.NotFound("Event.NotFound","the event WaitHandle the provide Id was no found");
        }
        if (Address.Create(command.Country, command.Line1, command.Line2, command.City,
                    command.State, command.ZipCode) is not Address address)
        {
            return Error.Validation("Customer.Address", "Address is not valid.");
        }

        Event eventTicket = Event.UpdateEvent(
            command.Id,
            command.EventDate,
            address,
            command.EventDescription,
            command.EventCost,
            command.EventState
        );

         _eventRepository.Update(eventTicket);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    
    }
}