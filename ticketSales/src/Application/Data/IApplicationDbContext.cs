using Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Event> Events{get; set;}

    Task<int> SaveChangesAsync(CancellationToken cancellationToken= default);
}