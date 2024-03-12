using Application.Events.Create;
using Application.Events.Delete;
using Application.Events.GetAll;
using Application.Events.GetById;
using Application.Events.Update;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("eventos")]
public class EventsController : ApiController
{
    private readonly ISender _mediator;

    public EventsController(ISender mediator)
    {
        _mediator = mediator?? throw new ArgumentNullException(nameof(mediator));
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
       var eventResult = await _mediator.Send(new GetAllEventsQuery());
       return eventResult.Match(
        eventTicket=> Ok(eventTicket),
        errors=> Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var eventResult = await _mediator.Send(new GetEventByIdQuery(id));

        return eventResult.Match(
            eventTicket => Ok(eventTicket),
            errors => Problem(errors)
        );
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEventCommand command)
    {
        var createEventResult = await _mediator.Send(command);
       
        return createEventResult.Match(
            eventTicket=> Ok(),
            errors=> Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEventCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("Event.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            eventId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteEventCommand(id));

        return deleteResult.Match(
            eventId => NoContent(),
            errors => Problem(errors)
        );
    }

}