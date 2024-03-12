using Domain.Events;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Events.Delete;

internal sealed class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, ErrorOr<Unit>>

{
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository?? throw new ArgumentNullException(nameof(eventRepository));
        _unitOfWork = unitOfWork?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
    {
        if(await _eventRepository.GetByIdAsync(new EventId(command.Id))is not Event eventTicket){
            return Error.NotFound("Evento.NotFound", "The event with the provide Id was nto found.");
        }
        _eventRepository.Delete(eventTicket);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}