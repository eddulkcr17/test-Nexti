using Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class EventRepository : IEventRepository
{
    
    private readonly ApplicationDbContext _context;

    public EventRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Event eventTicket)=> _context.Events.Add(eventTicket);

    public void Delete(Event eventTicket)=> _context.Events.Remove(eventTicket);

    
    public void Update(Event eventTicket)=> _context.Events.Update(eventTicket);
    public async Task<bool> ExistsAsync(EventId id)=> await _context.Events.AnyAsync(eventTicket=> eventTicket.Id == id);

    public async Task<List<Event>> GetAll()=> await _context.Events.ToListAsync();

    public async Task<Event?> GetByIdAsync(EventId id)=> await _context.Events.SingleOrDefaultAsync(e=> e.Id == id);

}