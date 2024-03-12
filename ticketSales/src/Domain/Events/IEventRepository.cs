namespace Domain.Events;

public interface IEventRepository
{
    Task<List<Event>> GetAll();
    Task<Event?> GetByIdAsync(EventId id);    
    Task<bool> ExistsAsync(EventId id);
    void Add(Event eventTicket);
    void Update(Event eventTicket);
    void Delete(Event eventTicket);
}


